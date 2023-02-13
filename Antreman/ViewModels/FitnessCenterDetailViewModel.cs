using Antreman.Models;

namespace Antreman.ViewModels
{
    public class FitnessCenterDetailViewModel
    {
        public FitnessCenter FitnessCenter { get; set; }
        public List<FitnessCenter> FitnessCenterList { get; set; }
        public District District { get; set; }
        public List<SubCategory> SubCategoryList { get;set; }
        public List<FitnessCenterSubCat> FitnessCenterSubCatList { get;set; }
        public List<Favoritee> MyFavoriteeList { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<City> CityList { get; set; }
        public List<District> DistrictList { get; set; }
        public int? SelectedCategoryID { get; set; }
        public int? SelectedCityID { get; set; }
        public SubCategory? SelectedSubCategory { get; set; }
        public Trainer Trainer { get; set; }
        public List<Trainer> TrainerList { get; set; }
        public List<Commentt> CommenttList { get; set; }

    }
}
