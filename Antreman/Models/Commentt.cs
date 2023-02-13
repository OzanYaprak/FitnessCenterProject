using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class Commentt
    {
        [Key]
        public int CommenttID { get; set; }

        [Required(ErrorMessage = "{0} Seçilmeli."), Display(Name = "Spor Salonu"), Range(1, 9999, ErrorMessage = "{0} seçilmeli")]
        public int FitnessCenterID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Yorum Eklenme Tarihi")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Tarih Uygun Formatta Değil.")]
        public DateTime CommenttDate { get; set; }

        [Required(ErrorMessage = "{0} Seçilmeli."), Display(Name = "Kullanıcı")]
        public int UserrID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "Yorum"), StringLength(400, MinimumLength = 6, ErrorMessage = "{0} {2} - {1} karakter olmalıdır.")]
        public string CommenttText { get; set; }




        //NAVİGASYON
        public FitnessCenter FitnessCenter { get; set; }
        public Userr Userr { get; set; }    

    }
}
