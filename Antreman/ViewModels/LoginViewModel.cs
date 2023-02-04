using System.ComponentModel.DataAnnotations;

namespace Antreman.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "E-posta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0},{2}-{1} karakter arasında olmalıdır")]
        public string Emaill { get; set; }


        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Şifre"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0},{2}-{1} karakter arasında olmalıdır")]
        public string Passwordd { get; set; }
    }  
}
 