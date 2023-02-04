using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class FitnessCenter
    {
        [Key]
        public int FitnessCenterID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Spor Salonu Adı"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} Min.{2} Maks.{1} karakter olmalıdır.")]
        public string FitnessCenterName { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "İlçe"), Range(1, 99, ErrorMessage = "{0} Seçilmeli")]
        public int DistrictID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Spor Salonu Adresi"), StringLength(200, MinimumLength = 15, ErrorMessage = "{0} Min.{2} Maks.{1} karakter olmalıdır.")]
        public string FitnessCenterAdress { get; set; }
        public int? Capacity { get; set; }






        //NAVİGASYON
        public District District { get; set; }

    }
}
