using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli"), Display(Name = "Ad-Soyad"), StringLength(50, MinimumLength = 3, ErrorMessage = "{0}, {2} - {1} karakter olmalı")]
        public string TrainerNameAndSurname { get; set; }
    }
}
