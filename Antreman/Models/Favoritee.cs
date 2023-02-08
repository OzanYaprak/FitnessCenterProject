using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class Favoritee
    {
        [Key]
        public int FavoriteeID { get; set; }
        [Required(ErrorMessage = "{0} Yapılması gerekiyor."), Display(Name = "Giriş")]
        public int UserrID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "İlçe"), Range(1, 9999, ErrorMessage = "{0} Seçilmeli")]
        public int FitnessCenterID { get; set; }

        public DateTime FavoriteeDate { get; set; }






        //NAVİGASYON
        public Userr Userr { get; set; }
        public FitnessCenter FitnessCenter { get; set; }

    }
}
