using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class City
    {
        [Key]
        public int CityID { get; set; }

        [Required(ErrorMessage = "{0} Belirtilmeli."), Display(Name = "İl"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} Min.{2} Maks.{1} karakter olmalıdır.")]
        public string CityName { get; set; }
    }
}
