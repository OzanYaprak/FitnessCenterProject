using Antreman.Data;
using Antreman.Models;
using Antreman.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Antreman.Controllers
{
    public class AntremanDetay : Controller
    {
        private readonly antremanDBContext _context;

        public AntremanDetay(antremanDBContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Detay(int id, int? kat, int? il, int? ilce, int? altkat, string sira, string aranan)
        {
            FitnessCenterDetailViewModel x = new FitnessCenterDetailViewModel();

            int MyUserrID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);

            x.FitnessCenter = await _context.FitnessCenters.Include(a => a.District).ThenInclude(a => a.City).FirstOrDefaultAsync(a => a.FitnessCenterID == id);
            x.MyFavoriteeList = await _context.Favoritees.Where(a => a.UserrID == MyUserrID).ToListAsync();
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

                if (seciliIlce != null)
                {
                    x.DistrictList = await _context.Districts.Where(b => b.CityID == seciliIlce.CityID).ToListAsync();
                }
            }

            x.SelectedCategoryID = kat;
            x.SelectedCityID = il;

            x.FitnessCenterList = await _context.FitnessCenters.Include(a => a.District).ThenInclude(a => a.City).Take(1).ToListAsync();

            x.CommenttList = await _context.Commentts.Include(a => a.Userr).Where(a => a.FitnessCenterID == id).OrderByDescending(a => a.CommenttID).Take(7).ToListAsync();

            return View(x);
        }


        [Authorize(Roles = "Uye")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumEkle(int id, string CommenttText)
        {
            int MyUserrID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);

            Commentt commentt = new Commentt() { FitnessCenterID = id, UserrID = MyUserrID, CommenttDate = DateTime.Now, CommenttText = CommenttText };
            await _context.AddAsync(commentt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Detay", "AntremanDetay", new { id = id });
        }


        //////////////////////////////////////////////////////////////



        [Authorize(Roles = "Uye")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FavoriEkle(int fitid)
        {
            int MyUserrID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            Favoritee favoritee = new Favoritee() { FitnessCenterID = fitid, UserrID = MyUserrID, FavoriteeDate = DateTime.Now };
            await _context.Favoritees.AddAsync(favoritee);
            await _context.SaveChangesAsync();
            return RedirectToAction("", "");
        }


        public async Task<IActionResult> FavoriKaldir(int fitid)
        {
            int MyUserrID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Sid)?.Value);
            Favoritee favoritee = await _context.Favoritees.FirstOrDefaultAsync(a => a.UserrID == MyUserrID && a.FitnessCenterID == fitid);
            _context.Favoritees.Remove(favoritee);
            await _context.SaveChangesAsync();
            return RedirectToAction("", "");
        }



        //////////////////////////////////////////////////////////////

        [Authorize(Roles = "Uye")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YorumSil(int id)
        {
            Commentt commentt = await _context.Commentts.FirstOrDefaultAsync(a => a.CommenttID == id);
            _context.Commentts.Remove(commentt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Detay", "AntremanDetay", new { id = commentt.FitnessCenterID });
        }

    }
}
