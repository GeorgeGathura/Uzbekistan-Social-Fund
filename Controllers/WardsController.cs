using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uzbekistan_Social_Fund.Data;
using Uzbekistan_Social_Fund.Models;

namespace Uzbekistan_Social_Fund.Controllers
{
    public class WardsController : Controller
    {
        private readonly SocialFundDbContext _context;

        public WardsController(SocialFundDbContext context)
        {
            _context = context;
        }

        // GET: Wards
        public async Task<IActionResult> Index()
        {
            var socialFundDbContext = _context.Wards.Include(w => w.SubCounty);
            return View(await socialFundDbContext.ToListAsync());
        }

        // GET: Wards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Wards
                .Include(w => w.SubCounty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ward == null)
            {
                return NotFound();
            }

            return View(ward);
        }

        // GET: Wards/Create
        public IActionResult Create()
        {
            ViewData["SubCountyId"] = new SelectList(_context.SubCounties, "Id", "Name");
            return View();
        }

        // POST: Wards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SubCountyId")] Ward ward)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ward);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubCountyId"] = new SelectList(_context.SubCounties, "Id", "Name", ward.SubCountyId);
            return View(ward);
        }

        // GET: Wards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Wards.FindAsync(id);
            if (ward == null)
            {
                return NotFound();
            }
            ViewData["SubCountyId"] = new SelectList(_context.SubCounties, "Id", "Name", ward.SubCountyId);
            return View(ward);
        }

        // POST: Wards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SubCountyId")] Ward ward)
        {
            if (id != ward.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ward);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WardExists(ward.Id))
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
            ViewData["SubCountyId"] = new SelectList(_context.SubCounties, "Id", "Name", ward.SubCountyId);
            return View(ward);
        }

        // GET: Wards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ward = await _context.Wards
                .Include(w => w.SubCounty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ward == null)
            {
                return NotFound();
            }

            return View(ward);
        }

        // POST: Wards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ward = await _context.Wards.FindAsync(id);
            _context.Wards.Remove(ward);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WardExists(int id)
        {
            return _context.Wards.Any(e => e.Id == id);
        }
    }
}
