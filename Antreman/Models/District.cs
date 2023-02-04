using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Antreman.Models
{
    public class District
    {
        [Key]
        public int DistrictID { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "İlçe Adı"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} {2} - {1} karakter olmalıdır.")]
        public string DistrictName { get; set; }

        [Required(ErrorMessage = "{0} Girilmeli."), Display(Name = "İl"), Range(1, 81, ErrorMessage = "{0} seçilmeli")]
        public int CityID { get; set; }






        //NAVİGASYON
        public City City { get; set; } 

    }
}
