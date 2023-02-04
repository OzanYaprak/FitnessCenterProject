using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }

        [Required(ErrorMessage = "{0} Belirtilmeli."), Display(Name = "Alt Kategori"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} Min.{2} Maks.{1} karakter olmalıdır.")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "{0} Belirtilmeli."), Display(Name = "Kategori"), Range(1,99, ErrorMessage ="{0} Seçilmeli")]
        public int CategoryID { get; set; }

        //Navigasyon

        public Category Category { get; set; }
    }
}
