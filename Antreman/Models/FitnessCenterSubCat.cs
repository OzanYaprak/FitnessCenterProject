using System.ComponentModel.DataAnnotations;

namespace Antreman.Models
{
    public class FitnessCenterSubCat
    {
        [Key]
        public int FitnessCenterSubCatID { get; set; }

        [Required(ErrorMessage = "{0} Seçilmeli."), Display(Name = "Spor Salonu"), Range(1, 200, ErrorMessage = "{0} Seçilmeli")]
        public int FitnessCenterID { get; set; }

        [Required(ErrorMessage = "{0} Seçilmeli."), Display(Name = "Spor Salonu"), Range(1, 1000, ErrorMessage = "{0} Seçilmeli")]
        public int SubCategoryID { get; set; }










        //NAVİGASYON

        public FitnessCenter FitnessCenter { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
