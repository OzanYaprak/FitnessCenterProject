using Antreman.Data;
using Antreman.Models;
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

        public async Task<IActionResult> Detay(int id)
        {
            FitnessCenter fitnessCenter = await _context.FitnessCenters.Include(a=>a.District).ThenInclude(a=>a.City).FirstOrDefaultAsync(a=>a.FitnessCenterID==id);
            return View(fitnessCenter);
        }
    }
}
