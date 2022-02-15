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
    public class HouseMembersController : Controller
    {
        private readonly SocialFundDbContext _context;

        public HouseMembersController(SocialFundDbContext context)
        {
            _context = context;
        }

        // GET: HouseMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.HouseMembers.ToListAsync());
        }

        // GET: HouseMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseMember = await _context.HouseMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (houseMember == null)
            {
                return NotFound();
            }

            return View(houseMember);
        }

        // GET: HouseMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,IDNumber,DateOfBirth,Relationship,ApplicantId")] HouseMember houseMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(houseMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(houseMember);
        }

        // GET: HouseMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseMember = await _context.HouseMembers.FindAsync(id);
            if (houseMember == null)
            {
                return NotFound();
            }
            return View(houseMember);
        }

        // POST: HouseMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,IDNumber,DateOfBirth,Relationship,ApplicantId")] HouseMember houseMember)
        {
            if (id != houseMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(houseMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseMemberExists(houseMember.Id))
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
            return View(houseMember);
        }

        // GET: HouseMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseMember = await _context.HouseMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (houseMember == null)
            {
                return NotFound();
            }

            return View(houseMember);
        }

        // POST: HouseMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var houseMember = await _context.HouseMembers.FindAsync(id);
            _context.HouseMembers.Remove(houseMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseMemberExists(int id)
        {
            return _context.HouseMembers.Any(e => e.Id == id);
        }
    }
}
