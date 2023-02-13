using Antreman.Data;
using Antreman.Models;
using Antreman.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Antreman.Controllers
{
    public class HomeController : Controller
    {
        private readonly antremanDBContext _context;

        public HomeController(antremanDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? kat, int? il, int? ilce, int? altkat, string sira,string aranan)
        {
            int MyUserrID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);

            HomeViewModel x = new HomeViewModel();


            x.CategoryList = await _context.Categories.ToListAsync();

            x.SelectedSubCategory = await _context.SubCategories.FirstOrDefaultAsync(a => a.SubCategoryID == altkat);

            x.SubCategoryList = await _context.SubCategories.Where(a => a.CategoryID == kat).ToListAsync();

            if (x.SubCategoryList.Count == 0 && altkat != null)
            {
                x.SubCategoryList = await _context.SubCategories.Where(a => a.CategoryID == x.SelectedSubCategory.CategoryID).ToListAsync();
            }



            x.CityList = await _context.Cities.ToListAsync();

            x.DistrictList = await _context.Districts.Where(a => a.CityID == il).ToListAsync();
            if (x.DistrictList.Count == 0)
            {
                District seciliIlce = await _context.Districts.FirstOrDefaultAsync(a => a.DistrictID == ilce);

                if (seciliIlce!=null)
                {
                    x.DistrictList = await _context.Districts.Where(b => b.CityID == seciliIlce.CityID).ToListAsync();
                }
            }

            x.SelectedCategoryID = kat;

            x.SelectedCityID = il;

            List<int> FitnessCenterListBySubCategoryID = _context.FitnessCenterSubCats.Where(a => a.FitnessCenterSubCatID == altkat || altkat == null).Select(a => a.FitnessCenterID).ToList();

            if (sira == "artan")
            {
                x.FitnessCenterList = await _context.FitnessCenters.
                        Where(a => a.DistrictID == ilce || ilce == null).
                        Where(a => x.DistrictList.Select(a => a.DistrictID).Contains(a.DistrictID) || il == null).
                        Where(a => FitnessCenterListBySubCategoryID.Contains(a.FitnessCenterID) || altkat == null).
                        Where(a=> a.FitnessCenterName.Contains(aranan) || aranan==null).
                        OrderBy(a => a.FitnessCenterName).
                        Include(a => a.District).
                        ThenInclude(a=>a.City).
                        Take(20).ToListAsync();
            }
            else if (sira=="azalan")
            {
                x.FitnessCenterList = await _context.FitnessCenters.
                        Where(a => a.DistrictID == ilce || ilce == null).                      
                        Where(a => x.DistrictList.Select(a => a.DistrictID).Contains(a.DistrictID) || il == null).                        
                        Where(a => FitnessCenterListBySubCategoryID.Contains(a.FitnessCenterID) || altkat == null).
                        Where(a => a.FitnessCenterName.Contains(aranan) || aranan == null).
                        OrderByDescending(a => a.FitnessCenterName).
                        Include(a => a.District).
                        ThenInclude(a => a.City).
                        Take(20).ToListAsync();
            }
            else if (sira== "ilceartan")
            {
                x.FitnessCenterList = await _context.FitnessCenters.
                        Where(a => a.DistrictID == ilce || ilce == null).                      
                        Where(a => x.DistrictList.Select(a => a.DistrictID).Contains(a.DistrictID) || il == null).                        
                        Where(a => FitnessCenterListBySubCategoryID.Contains(a.FitnessCenterID) || altkat == null).
                        Where(a => a.FitnessCenterName.Contains(aranan) || aranan == null).
                        OrderBy(a => a.District.DistrictID).
                        Include(a => a.District).
                        ThenInclude(a => a.City).
                        Take(20).ToListAsync();
            }
            else if (sira == "ilceazalan")
            {
                x.FitnessCenterList = await _context.FitnessCenters.
                        Where(a => a.DistrictID == ilce || ilce == null).                      
                        Where(a => x.DistrictList.Select(a => a.DistrictID).Contains(a.DistrictID) || il == null).                        
                        Where(a => FitnessCenterListBySubCategoryID.Contains(a.FitnessCenterID) || altkat == null).
                        Where(a => a.FitnessCenterName.Contains(aranan) || aranan == null).
                        OrderByDescending(a => a.District.DistrictID).
                        Include(a => a.District).
                        ThenInclude(a => a.City).
                        Take(20).ToListAsync();
            }
            else
            {
                x.FitnessCenterList = await _context.FitnessCenters.
                        Where(a => a.DistrictID == ilce || ilce == null).                      
                        Where(a => x.DistrictList.Select(a => a.DistrictID).Contains(a.DistrictID) || il == null).                        
                        Where(a => FitnessCenterListBySubCategoryID.Contains(a.FitnessCenterID) || altkat == null).
                        Where(a => a.FitnessCenterName.Contains(aranan) || aranan == null).
                        Include(a => a.District).
                        ThenInclude(a => a.City).
                        Take(20).ToListAsync();
            }

            

            x.MyFavoriteeList = await _context.Favoritees.Where(a => a.UserrID == MyUserrID).ToListAsync();

            return View(x);
        }


        public IActionResult AramaYap(string arananMetin)
        {
            return RedirectToAction("", "", new {aranan=arananMetin});
        }

        [Authorize(Roles ="Uye")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FavoriEkle(int fitid)
        {
            int MyUserrID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            Favoritee favoritee = new Favoritee() { FitnessCenterID = fitid, UserrID = MyUserrID, FavoriteeDate = DateTime.Now };
            await _context.Favoritees.AddAsync(favoritee);
            await _context.SaveChangesAsync();
            return RedirectToAction("","");
        }


        public async Task<IActionResult> FavoriKaldir(int fitid)
        {
            int MyUserrID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            Favoritee favoritee = await _context.Favoritees.FirstOrDefaultAsync(a=>a.UserrID==MyUserrID && a.FitnessCenterID==fitid);
            _context.Favoritees.Remove(favoritee);
            await _context.SaveChangesAsync();
            return RedirectToAction("", "");
        }




        











        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}