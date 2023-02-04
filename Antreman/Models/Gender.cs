using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "{0} Belirtilmeli."), Display(Name = "Cinsiyet"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} Min.{2} Maks.{1} karakter olmalıdır.")]
        public string GenderName { get; set; }
    }
}
