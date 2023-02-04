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
    public class CinsiyetController : Controller
    {
        private readonly antremanDBContext _context;

        public CinsiyetController(antremanDBContext context)
        {
            _context = context;
        }

        // GET: Cinsiyet
        public async Task<IActionResult> Index()
        {
              return View(await _context.Genders.ToListAsync());
        }

        // GET: Cinsiyet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Genders == null)
            {
                return NotFound();
            }

            var gender = await _context.Genders
                .FirstOrDefaultAsync(m => m.GenderID == id);
            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        // GET: Cinsiyet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinsiyet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenderID,GenderName")] Gender gender)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gender);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gender);
        }

        // GET: Cinsiyet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Genders == null)
            {
                return NotFound();
            }

            var gender = await _context.Genders.FindAsync(id);
            if (gender == null)
            {
                return NotFound();
            }
            return View(gender);
        }

        // POST: Cinsiyet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenderID,GenderName")] Gender gender)
        {
            if (id != gender.GenderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderExists(gender.GenderID))
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
            return View(gender);
        }

        // GET: Cinsiyet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Genders == null)
            {
                return NotFound();
            }

            var gender = await _context.Genders
                .FirstOrDefaultAsync(m => m.GenderID == id);
            if (gender == null)
            {
                return NotFound();
            }

            return View(gender);
        }

        // POST: Cinsiyet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Genders == null)
            {
                return Problem("Entity set 'antremanDBContext.Genders'  is null.");
            }
            var gender = await _context.Genders.FindAsync(id);
            if (gender != null)
            {
                _context.Genders.Remove(gender);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderExists(int id)
        {
          return _context.Genders.Any(e => e.GenderID == id);
        }
    }
}
