using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeAppMVC.Models
{
    public class CollegeApplication
    {
        public int Id { get; set; }

        public byte[]? ProfileImage { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only alphabets")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone number must contain exactly 10 digits")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DOBValidation]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Range(50, 100, ErrorMessage = "Percentage must be between 50 and 100")]
        [Display(Name = "12th Percentage")]
        public double Percentage { get; set; }

        [Required]
        [StringLength(100)]
        public string Course { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }
    }

    public class DOBValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Date of Birth is required");

            DateTime dob = (DateTime)value;

            if (dob > DateTime.Now)
                return new ValidationResult("Date of Birth cannot be in the future");

            if (dob > DateTime.Now.AddYears(-16))
                return new ValidationResult("Applicant must be at least 16 years old");

            return ValidationResult.Success;
        }
    }
}
