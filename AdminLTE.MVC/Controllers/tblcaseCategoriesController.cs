using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS.MVC.Data;
using CMS.Models;

namespace CMS.Controllers
{
    public class tblcaseCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblcaseCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblcaseCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblcaseCategory.ToListAsync());
        }

        // GET: tblcaseCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcaseCategory = await _context.tblcaseCategory
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblcaseCategory == null)
            {
                return NotFound();
            }

            return View(tblcaseCategory);
        }

        // GET: tblcaseCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblcaseCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Categoryname")] tblcaseCategory tblcaseCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblcaseCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblcaseCategory);
        }

        // GET: tblcaseCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcaseCategory = await _context.tblcaseCategory.FindAsync(id);
            if (tblcaseCategory == null)
            {
                return NotFound();
            }
            return View(tblcaseCategory);
        }

        // POST: tblcaseCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Categoryname")] tblcaseCategory tblcaseCategory)
        {
            if (id != tblcaseCategory.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblcaseCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblcaseCategoryExists(tblcaseCategory.id))
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
            return View(tblcaseCategory);
        }

        // GET: tblcaseCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcaseCategory = await _context.tblcaseCategory
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblcaseCategory == null)
            {
                return NotFound();
            }

            return View(tblcaseCategory);
        }

        // POST: tblcaseCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblcaseCategory = await _context.tblcaseCategory.FindAsync(id);
            _context.tblcaseCategory.Remove(tblcaseCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblcaseCategoryExists(int id)
        {
            return _context.tblcaseCategory.Any(e => e.id == id);
        }
    }
}
