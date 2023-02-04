using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Antreman.Data;
using Antreman.Models;

namespace Antreman.Controllers
{
    public class SporSalonuAltKategoriController : Controller
    {
        private readonly antremanDBContext _context;

        public SporSalonuAltKategoriController(antremanDBContext context)
        {
            _context = context;
        }

        // GET: SporSalonuAltKategori
        public async Task<IActionResult> Index()
        {
            var antremanDBContext = _context.FitnessCenterSubCat.Include(f => f.FitnessCenter).Include(f => f.SubCategory);
            return View(await antremanDBContext.ToListAsync());
        }

        // GET: SporSalonuAltKategori/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FitnessCenterSubCat == null)
            {
                return NotFound();
            }

            var fitnessCenterSubCat = await _context.FitnessCenterSubCat
                .Include(f => f.FitnessCenter)
                .Include(f => f.SubCategory)
                .FirstOrDefaultAsync(m => m.FitnessCenterSubCatID == id);
            if (fitnessCenterSubCat == null)
            {
                return NotFound();
            }

            return View(fitnessCenterSubCat);
        }

        // GET: SporSalonuAltKategori/Create
        public IActionResult Create()
        {
            ViewData["FitnessCenterID"] = new SelectList(_context.FitnessCenters, "FitnessCenterID", "FitnessCenterAdress");
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryName");
            return View();
        }

        // POST: SporSalonuAltKategori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FitnessCenterSubCatID,FitnessCenterID,SubCategoryID")] FitnessCenterSubCat fitnessCenterSubCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessCenterSubCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FitnessCenterID"] = new SelectList(_context.FitnessCenters, "FitnessCenterID", "FitnessCenterAdress", fitnessCenterSubCat.FitnessCenterID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryName", fitnessCenterSubCat.SubCategoryID);
            return View(fitnessCenterSubCat);
        }

        // GET: SporSalonuAltKategori/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FitnessCenterSubCat == null)
            {
                return NotFound();
            }

            var fitnessCenterSubCat = await _context.FitnessCenterSubCat.FindAsync(id);
            if (fitnessCenterSubCat == null)
            {
                return NotFound();
            }
            ViewData["FitnessCenterID"] = new SelectList(_context.FitnessCenters, "FitnessCenterID", "FitnessCenterAdress", fitnessCenterSubCat.FitnessCenterID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryName", fitnessCenterSubCat.SubCategoryID);
            return View(fitnessCenterSubCat);
        }

        // POST: SporSalonuAltKategori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FitnessCenterSubCatID,FitnessCenterID,SubCategoryID")] FitnessCenterSubCat fitnessCenterSubCat)
        {
            if (id != fitnessCenterSubCat.FitnessCenterSubCatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fitnessCenterSubCat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessCenterSubCatExists(fitnessCenterSubCat.FitnessCenterSubCatID))
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
            ViewData["FitnessCenterID"] = new SelectList(_context.FitnessCenters, "FitnessCenterID", "FitnessCenterAdress", fitnessCenterSubCat.FitnessCenterID);
            ViewData["SubCategoryID"] = new SelectList(_context.SubCategories, "SubCategoryID", "SubCategoryName", fitnessCenterSubCat.SubCategoryID);
            return View(fitnessCenterSubCat);
        }

        // GET: SporSalonuAltKategori/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FitnessCenterSubCat == null)
            {
                return NotFound();
            }

            var fitnessCenterSubCat = await _context.FitnessCenterSubCat
                .Include(f => f.FitnessCenter)
                .Include(f => f.SubCategory)
                .FirstOrDefaultAsync(m => m.FitnessCenterSubCatID == id);
            if (fitnessCenterSubCat == null)
            {
                return NotFound();
            }

            return View(fitnessCenterSubCat);
        }

        // POST: SporSalonuAltKategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FitnessCenterSubCat == null)
            {
                return Problem("Entity set 'antremanDBContext.FitnessCenterSubCat'  is null.");
            }
            var fitnessCenterSubCat = await _context.FitnessCenterSubCat.FindAsync(id);
            if (fitnessCenterSubCat != null)
            {
                _context.FitnessCenterSubCat.Remove(fitnessCenterSubCat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessCenterSubCatExists(int id)
        {
          return _context.FitnessCenterSubCat.Any(e => e.FitnessCenterSubCatID == id);
        }
    }
}
