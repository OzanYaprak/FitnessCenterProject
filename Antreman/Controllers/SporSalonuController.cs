using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Antreman.Data;
using Antreman.Models;
using Antreman.ViewModels;

namespace Antreman.Controllers
{
    public class SporSalonuController : Controller
    {
        private readonly antremanDBContext _context;

        public SporSalonuController(antremanDBContext context)
        {
            _context = context;
        }

        // GET: SporSalonu
        public async Task<IActionResult> Index()
        {
            var antremanDBContext = _context.FitnessCenters.Include(f => f.District);
            return View(await antremanDBContext.ToListAsync());
        }

        // GET: SporSalonu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FitnessCenters == null)
            {
                return NotFound();
            }

            FitnessCenterDetailViewModel x = new FitnessCenterDetailViewModel();

            x.FitnessCenterSubCatList = await _context.FitnessCenterSubCats.Include(a=>a.SubCategory).Where(a=>a.FitnessCenterID==id).ToListAsync();
            x.FitnessCenter = await _context.FitnessCenters.Include(s => s.District).FirstOrDefaultAsync(m => m.FitnessCenterID == id);
            x.SubCategoryList = await _context.SubCategories.Where(a=> !(x.FitnessCenterSubCatList.Select(a=>a.SubCategoryID).Contains(a.SubCategoryID))).ToListAsync();

            if (x.FitnessCenter == null)
            {
                return NotFound();
            }

            return View(x);
        }

        // GET: SporSalonu/Create
        public IActionResult Create()
        {
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName");
            return View();
        }

        // POST: SporSalonu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FitnessCenterID,FitnessCenterName,DistrictID,FitnessCenterAdress,Capacity")] FitnessCenter fitnessCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName", fitnessCenter.DistrictID);
            return View(fitnessCenter);
        }

        // GET: SporSalonu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FitnessCenters == null)
            {
                return NotFound();
            }

            var fitnessCenter = await _context.FitnessCenters.FindAsync(id);
            if (fitnessCenter == null)
            {
                return NotFound();
            }
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName", fitnessCenter.DistrictID);
            return View(fitnessCenter);
        }

        // POST: SporSalonu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FitnessCenterID,FitnessCenterName,DistrictID,FitnessCenterAdress,Capacity")] FitnessCenter fitnessCenter)
        {
            if (id != fitnessCenter.FitnessCenterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnessCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessCenterExists(fitnessCenter.FitnessCenterID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictID"] = new SelectList(_context.Districts, "DistrictID", "DistrictName", fitnessCenter.DistrictID);
            return View(fitnessCenter);
        }

        // GET: SporSalonu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FitnessCenters == null)
            {
                return NotFound();
            }

            var fitnessCenter = await _context.FitnessCenters
                .Include(f => f.District)
                .FirstOrDefaultAsync(m => m.FitnessCenterID == id);
            if (fitnessCenter == null)
            {
                return NotFound();
            }

            return View(fitnessCenter);
        }

        // POST: SporSalonu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FitnessCenters == null)
            {
                return Problem("Entity set 'antremanDBContext.FitnessCenters'  is null.");
            }
            var fitnessCenter = await _context.FitnessCenters.FindAsync(id);
            if (fitnessCenter != null)
            {
                _context.FitnessCenters.Remove(fitnessCenter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessCenterExists(int id)
        {
            return _context.FitnessCenters.Any(e => e.FitnessCenterID == id);
        }







        // POST: SporSalonuAltKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubCategoryToFitnessCenter (int id,[Bind("FitnessCenterSubCatID,FitnessCenterID,SubCategoryID")] FitnessCenterSubCat fitnessCenterSubCat)
        {
            fitnessCenterSubCat.FitnessCenterID = id;
            _context.Add(fitnessCenterSubCat);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "SporSalonu",new {@id = id});
        }










    }
}
