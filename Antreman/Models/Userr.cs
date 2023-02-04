using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Antreman.Models
{
    public class Userr
    {
        [Key]
        public int UserrID { get; set; }

        [Required(ErrorMessage = "{0} gerekli"),Display(Name ="E-posta"),StringLength(50, MinimumLength = 6, ErrorMessage ="{0},{2}-{1} karakter arasında olmalıdır")]
        public string Emaill { get; set; }


        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Şifre"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0},{2}-{1} karakter arasında olmalıdır")]
        public string Passwordd { get; set; }

        [NotMapped,Display(Name = "Şifre Tekrarı"), DataType(DataType.Password), Compare("Password", ErrorMessage = "Şifreler Uyumsuz")]
        public string PasswordRepeatt { get; set; }

        [Required(ErrorMessage ="{0} gerekli"), Display(Name = "Rol")]
        public byte RoleeID { get; set; }



        //NAVİGAASYON
        public Rolee Rolee { get; set; }
    }
}
