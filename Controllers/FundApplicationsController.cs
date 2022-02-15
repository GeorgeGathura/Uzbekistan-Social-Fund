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
    public class FundApplicationsController : Controller
    {
        private readonly SocialFundDbContext _context;

        public FundApplicationsController(SocialFundDbContext context)
        {
            _context = context;
        }

        // GET: FundApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.FundApplication.ToListAsync());
        }

        // GET: FundApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundApplication = await _context.FundApplication
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fundApplication == null)
            {
                return NotFound();
            }

            return View(fundApplication);
        }

        // GET: FundApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FundApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BenefitTwoYearOld,BenefitFamilyWithTeens,BenefitLowIncomeFamily,ApplicantId")] FundApplication fundApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fundApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fundApplication);
        }

        // GET: FundApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundApplication = await _context.FundApplication.FindAsync(id);
            if (fundApplication == null)
            {
                return NotFound();
            }
            return View(fundApplication);
        }

        // POST: FundApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BenefitTwoYearOld,BenefitFamilyWithTeens,BenefitLowIncomeFamily,ApplicantId")] FundApplication fundApplication)
        {
            if (id != fundApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundApplicationExists(fundApplication.Id))
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
            return View(fundApplication);
        }

        // GET: FundApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fundApplication = await _context.FundApplication
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fundApplication == null)
            {
                return NotFound();
            }

            return View(fundApplication);
        }

        // POST: FundApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fundApplication = await _context.FundApplication.FindAsync(id);
            _context.FundApplication.Remove(fundApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundApplicationExists(int id)
        {
            return _context.FundApplication.Any(e => e.Id == id);
        }
    }
}
