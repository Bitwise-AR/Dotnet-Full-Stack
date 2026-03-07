using System.ComponentModel.DataAnnotations;

namespace LibraryMVC.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Title cannot exceed 15 characters")]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(0.01, float.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public float Price { get; set; }
    }
}