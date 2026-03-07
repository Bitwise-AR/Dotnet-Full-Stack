using CollegeAppMVC.Data;
using CollegeAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Properties;
using System.IO;
using iText.Kernel.Colors;
using iText.Layout.Borders;
using iText.Layout.Properties;

namespace CollegeApplicationMVC.Controllers
{
    public class CollegeApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollegeApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeApplications.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CollegeApplication application)
        {
            if (application.ImageFile == null || application.ImageFile.Length == 0)
            {
                ModelState.AddModelError("ImageFile", "Image is required.");
            }

            if (application.ImageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(application.ImageFile.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ImageFile", "Only .jpg, .jpeg, .png files allowed.");
                }

                if (application.ImageFile.Length > 1 * 1024 * 1024)
                {
                    ModelState.AddModelError("ImageFile", "File size must be less than 1MB.");
                }

                if (ModelState.IsValid)
                {
                    using (var ms = new MemoryStream())
                    {
                        await application.ImageFile.CopyToAsync(ms);
                        application.ProfileImage = ms.ToArray();
                    }
                }
            }

            if (ModelState.IsValid)
            {
                bool emailExists = await _context.CollegeApplications
                    .AnyAsync(c => c.Email == application.Email);

                if (emailExists)
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                    return View(application);
                }

                bool phoneExists = await _context.CollegeApplications
                    .AnyAsync(c => c.PhoneNumber == application.PhoneNumber);

                if (phoneExists)
                {
                    ModelState.AddModelError("PhoneNumber", "Phone number already exists.");
                    return View(application);
                }

                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(application);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var app = await _context.CollegeApplications.FindAsync(id);
            if (app == null) return NotFound();
            return View(app);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CollegeApplication application)
        {
            if (id != application.Id)
                return NotFound();

            var existingStudent = await _context.CollegeApplications.FindAsync(id);

            if (existingStudent == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                existingStudent.FullName = application.FullName;
                existingStudent.Email = application.Email;
                existingStudent.Gender = application.Gender;
                existingStudent.PhoneNumber = application.PhoneNumber;
                existingStudent.CountryCode = application.CountryCode;
                existingStudent.DateOfBirth = application.DateOfBirth;
                existingStudent.Percentage = application.Percentage;
                existingStudent.Course = application.Course;
                existingStudent.Address = application.Address;

                // If new image uploaded → replace
                if (application.ImageFile != null && application.ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await application.ImageFile.CopyToAsync(ms);
                        existingStudent.ProfileImage = ms.ToArray();
                    }
                }

                // If no new image uploaded AND no existing image → block
                if ((application.ImageFile == null || application.ImageFile.Length == 0)
                    && existingStudent.ProfileImage == null)
                {
                    ModelState.AddModelError("ImageFile", "Image is required.");
                    return View(application);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(application);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.CollegeApplications
                .FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var app = await _context.CollegeApplications.FindAsync(id);
            if (app == null) return NotFound();
            return View(app);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var app = await _context.CollegeApplications.FindAsync(id);
            _context.CollegeApplications.Remove(app);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DownloadPdf(int id)
        {
            var student = await _context.CollegeApplications
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
                return NotFound();

            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont normalFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                // ===== University Header =====
                document.Add(new Paragraph("Lovely Professional University")
                    .SetFont(boldFont)
                    .SetFontSize(18)
                    .SetTextAlignment(TextAlignment.CENTER));

                document.Add(new Paragraph("Punjab, India")
                    .SetFont(normalFont)
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.CENTER));

                document.Add(new Paragraph("\n"));

                // ===== Title =====
                document.Add(new Paragraph("Student Admission Details")
                    .SetFont(boldFont)
                    .SetFontSize(16)
                    .SetTextAlignment(TextAlignment.CENTER));

                document.Add(new Paragraph("\n"));

                // ===== Student Image =====
                if (student.ProfileImage != null)
                {
                    ImageData imageData = ImageDataFactory.Create(student.ProfileImage);
                    Image img = new Image(imageData)
                        .ScaleToFit(120, 120)
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER);

                    document.Add(img);
                    document.Add(new Paragraph("\n"));
                }

                // ===== Table Layout =====
                Table table = new Table(2).UseAllAvailableWidth();

                void AddRow(string label, string value)
                {
                    Cell labelCell = new Cell()
                        .Add(new Paragraph(label).SetFont(boldFont))
                        .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY);

                    Cell valueCell = new Cell()
                        .Add(new Paragraph(value).SetFont(normalFont));

                    table.AddCell(labelCell);
                    table.AddCell(valueCell);
                }

                AddRow("Full Name", student.FullName);
                AddRow("Email", student.Email);
                AddRow("Gender", student.Gender);
                AddRow("Phone", student.CountryCode + " " + student.PhoneNumber);
                AddRow("Date of Birth", student.DateOfBirth.ToShortDateString());
                AddRow("12th Percentage", student.Percentage + "%");
                AddRow("Course", student.Course);
                AddRow("Address", student.Address);

                document.Add(table);

                document.Add(new Paragraph("\n"));

                // ===== Footer =====
                document.Add(new Paragraph("Generated on: " + DateTime.Now.ToString("dd MMM yyyy"))
                    .SetFontSize(10)
                    .SetTextAlignment(TextAlignment.RIGHT));

                document.Close();

                return File(stream.ToArray(), "application/pdf", $"{student.FullName}_Details.pdf");
            }
        }

        public async Task<IActionResult> GenerateIdCard(int id)
        {
            var student = await _context.CollegeApplications
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public async Task<IActionResult> DownloadIdCard(int id)
        {
            var student = await _context.CollegeApplications
                .FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
                return NotFound();

            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont normal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                // ===== Create ID Card Container (Single Cell Table) =====
                Table cardTable = new Table(1);
                cardTable.SetWidth(300);
                cardTable.SetHorizontalAlignment(HorizontalAlignment.CENTER);

                Cell cardCell = new Cell();
                cardCell.SetPadding(20);
                cardCell.SetBackgroundColor(new DeviceRgb(20, 25, 40)); // dark background
                cardCell.SetBorder(new SolidBorder(new DeviceRgb(16, 185, 129), 2)); // green border
                cardCell.SetBorderRadius(new BorderRadius(15));

                // ===== University Header =====
                cardCell.Add(new Paragraph("Lovely Professional University")
                    .SetFont(bold)
                    .SetFontSize(14)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardCell.Add(new Paragraph("Punjab, India")
                    .SetFont(normal)
                    .SetFontSize(10)
                    .SetFontColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardCell.Add(new Paragraph("\n"));

                // ===== Student Image =====
                if (student.ProfileImage != null)
                {
                    ImageData imgData = ImageDataFactory.Create(student.ProfileImage);
                    Image img = new Image(imgData)
                        .ScaleToFit(100, 100)
                        .SetHorizontalAlignment(HorizontalAlignment.CENTER);

                    cardCell.Add(img);
                }

                cardCell.Add(new Paragraph("\n"));

                // ===== Student Name =====
                cardCell.Add(new Paragraph(student.FullName)
                    .SetFont(bold)
                    .SetFontSize(16)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardCell.Add(new Paragraph("\n"));

                // ===== Details Section =====
                cardCell.Add(new Paragraph("Course: " + student.Course)
                    .SetFont(normal)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetFontSize(11)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardCell.Add(new Paragraph("Gender: " + student.Gender)
                    .SetFont(normal)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetFontSize(11)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardCell.Add(new Paragraph("DOB: " + student.DateOfBirth.ToShortDateString())
                    .SetFont(normal)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetFontSize(11)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardCell.Add(new Paragraph("Phone: " + student.CountryCode + " " + student.PhoneNumber)
                    .SetFont(normal)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetFontSize(11)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardCell.Add(new Paragraph("\n"));

                // ===== ID Number =====
                cardCell.Add(new Paragraph("ID: LPU" + student.Id.ToString("D4"))
                    .SetFont(bold)
                    .SetFontColor(new DeviceRgb(16, 185, 129))
                    .SetFontSize(13)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardCell.Add(new Paragraph("\n"));

                cardCell.Add(new Paragraph("Valid Till 2028")
                    .SetFontSize(9)
                    .SetFontColor(ColorConstants.GRAY)
                    .SetTextAlignment(TextAlignment.CENTER));

                cardTable.AddCell(cardCell);
                document.Add(cardTable);

                document.Close();

                return File(stream.ToArray(),
                    "application/pdf",
                    $"{student.FullName}_IDCard.pdf");
            }
        }
    }
}