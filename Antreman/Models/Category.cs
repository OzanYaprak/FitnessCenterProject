using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "{0} Belirtilmeli."), Display(Name = "Kategori"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} Min.{2} Maks.{1} karakter olmalıdır.")]
        public string CategoryName { get; set; }
    }
}
