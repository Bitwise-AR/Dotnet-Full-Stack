using DocumentVault.Data;
using DocumentVault.Models;
using DocumentVault.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVault.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _service;

        public DocumentController(IDocumentService service)
        {
            _service = service;
        }

        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, string uploadedBy)
        {
            try
            {
                var id = await _service.UploadAsync(file, uploadedBy);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Download(int id)
        {
            try
            {
                var (bytes, type, name) = await _service.DownloadAsync(id);
                return File(bytes, type, name);
            }
            catch
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Index()
        {
            var documents = await _service.GetAllAsync();
            return View(documents);
        }
    }
}
