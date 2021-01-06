using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS.MVC.Data;
using CMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Controllers
{
    [AllowAnonymous]
    public class tblcourtsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblcourtsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblcourts
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblcourt.ToListAsync());
        }

        // GET: tblcourts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcourt = await _context.tblcourt
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblcourt == null)
            {
                return NotFound();
            }

            return View(tblcourt);
        }

        // GET: tblcourts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblcourts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Courtname")] tblcourt tblcourt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblcourt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblcourt);
        }

        // GET: tblcourts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcourt = await _context.tblcourt.FindAsync(id);
            if (tblcourt == null)
            {
                return NotFound();
            }
            return View(tblcourt);
        }

        // POST: tblcourts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Courtname")] tblcourt tblcourt)
        {
            if (id != tblcourt.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblcourt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblcourtExists(tblcourt.id))
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
            return View(tblcourt);
        }

        // GET: tblcourts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblcourt = await _context.tblcourt
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblcourt == null)
            {
                return NotFound();
            }

            return View(tblcourt);
        }

        // POST: tblcourts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblcourt = await _context.tblcourt.FindAsync(id);
            _context.tblcourt.Remove(tblcourt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblcourtExists(int id)
        {
            return _context.tblcourt.Any(e => e.id == id);
        }
    }
}
