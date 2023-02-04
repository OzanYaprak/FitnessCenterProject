using Antreman.Models;

namespace Antreman.ViewModels
{
    public class FitnessCenterDetailViewModel
    {
        public FitnessCenter FitnessCenter { get; set; }
        public List<SubCategory> SubCategoryList { get;set; }
        public List<FitnessCenterSubCat> FitnessCenterSubCatList { get;set; }
    }
}
