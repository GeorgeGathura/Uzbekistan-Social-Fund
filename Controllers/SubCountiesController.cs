using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uzbekistan_Social_Fund.Data;
using Uzbekistan_Social_Fund.Models;

namespace Uzbekistan_Social_Fund.Controllers
{
    [Authorize]
    public class SubCountiesController : Controller
    {
        private readonly SocialFundDbContext _context;

        public SubCountiesController(SocialFundDbContext context)
        {
            _context = context;
        }

        // GET: SubCounties
        public async Task<IActionResult> Index()
        {
            var socialFundDbContext = _context.SubCounties.Include(s => s.County);
            return View(await socialFundDbContext.ToListAsync());
        }

        // GET: SubCounties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCounty = await _context.SubCounties
                .Include(s => s.County)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCounty == null)
            {
                return NotFound();
            }

            return View(subCounty);
        }

        // GET: SubCounties/Create
        public IActionResult Create()
        {
            ViewData["CountyId"] = new SelectList(_context.Counties, "Id", "Name");
            return View();
        }

        // POST: SubCounties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountyId")] SubCounty subCounty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCounty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountyId"] = new SelectList(_context.Counties, "Id", "Name", subCounty.CountyId);
            return View(subCounty);
        }

        // GET: SubCounties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCounty = await _context.SubCounties.FindAsync(id);
            if (subCounty == null)
            {
                return NotFound();
            }
            ViewData["CountyId"] = new SelectList(_context.Counties, "Id", "Name", subCounty.CountyId);
            return View(subCounty);
        }

        // POST: SubCounties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountyId")] SubCounty subCounty)
        {
            if (id != subCounty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCounty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCountyExists(subCounty.Id))
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
            ViewData["CountyId"] = new SelectList(_context.Counties, "Id", "Name", subCounty.CountyId);
            return View(subCounty);
        }

        // GET: SubCounties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCounty = await _context.SubCounties
                .Include(s => s.County)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCounty == null)
            {
                return NotFound();
            }

            return View(subCounty);
        }

        // POST: SubCounties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCounty = await _context.SubCounties.FindAsync(id);
            _context.SubCounties.Remove(subCounty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCountyExists(int id)
        {
            return _context.SubCounties.Any(e => e.Id == id);
        }
    }
}
