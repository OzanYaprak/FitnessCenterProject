using System.ComponentModel.DataAnnotations;

namespace Antreman.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "E-posta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0},{2}-{1} karakter arasında olmalıdır"), DataType(DataType.EmailAddress, ErrorMessage = "Geçersiz {0}")]
        public string Emaill { get; set; }


        [Required(ErrorMessage = "{0} gerekli"), Display(Name = "Şifre"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0},{2}-{1} karakter arasında olmalıdır"), DataType(DataType.Password)]
        public string Passwordd { get; set; }
    }  
}
 