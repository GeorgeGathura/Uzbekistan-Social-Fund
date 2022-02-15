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
    public class MemberEducationsController : Controller
    {
        private readonly SocialFundDbContext _context;

        public MemberEducationsController(SocialFundDbContext context)
        {
            _context = context;
        }

        // GET: MemberEducations
        public async Task<IActionResult> Index()
        {
            var socialFundDbContext = _context.MemberEducations.Include(m => m.HouseMember);
            return View(await socialFundDbContext.ToListAsync());
        }

        // GET: MemberEducations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEducation = await _context.MemberEducations
                .Include(m => m.HouseMember)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberEducation == null)
            {
                return NotFound();
            }

            return View(memberEducation);
        }

        // GET: MemberEducations/Create
        public IActionResult Create()
        {
            ViewData["HouseMemberId"] = new SelectList(_context.HouseMembers, "Id", "FullName");
            return View();
        }

        // POST: MemberEducations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LangugeProfiency,WriteProfiency,SchoolAttendance,SchoolLevel,HasAttendedSchool,HighestSchoolLevel,HouseMemberId")] MemberEducation memberEducation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberEducation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseMemberId"] = new SelectList(_context.HouseMembers, "Id", "FullName", memberEducation.HouseMemberId);
            return View(memberEducation);
        }

        // GET: MemberEducations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEducation = await _context.MemberEducations.FindAsync(id);
            if (memberEducation == null)
            {
                return NotFound();
            }
            ViewData["HouseMemberId"] = new SelectList(_context.HouseMembers, "Id", "FullName", memberEducation.HouseMemberId);
            return View(memberEducation);
        }

        // POST: MemberEducations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LangugeProfiency,WriteProfiency,SchoolAttendance,SchoolLevel,HasAttendedSchool,HighestSchoolLevel,HouseMemberId")] MemberEducation memberEducation)
        {
            if (id != memberEducation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberEducation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberEducationExists(memberEducation.Id))
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
            ViewData["HouseMemberId"] = new SelectList(_context.HouseMembers, "Id", "FullName", memberEducation.HouseMemberId);
            return View(memberEducation);
        }

        // GET: MemberEducations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberEducation = await _context.MemberEducations
                .Include(m => m.HouseMember)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberEducation == null)
            {
                return NotFound();
            }

            return View(memberEducation);
        }

        // POST: MemberEducations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberEducation = await _context.MemberEducations.FindAsync(id);
            _context.MemberEducations.Remove(memberEducation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberEducationExists(int id)
        {
            return _context.MemberEducations.Any(e => e.Id == id);
        }
    }
}
