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
    public class tblClientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblClientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblClients.ToListAsync());
        }

        // GET: tblClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClients = await _context.tblClients
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblClients == null)
            {
                return NotFound();
            }

            return View(tblClients);
        }

        // GET: tblClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,FatherName,Type,CNIC,Dateofbirth,Phone,Address")] tblClients tblClients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblClients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblClients);
        }

        // GET: tblClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClients = await _context.tblClients.FindAsync(id);
            if (tblClients == null)
            {
                return NotFound();
            }
            return View(tblClients);
        }

        // POST: tblClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,FatherName,Type,CNIC,Dateofbirth,Phone,Address")] tblClients tblClients)
        {
            if (id != tblClients.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblClients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblClientsExists(tblClients.id))
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
            return View(tblClients);
        }

        // GET: tblClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblClients = await _context.tblClients
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblClients == null)
            {
                return NotFound();
            }

            return View(tblClients);
        }

        // POST: tblClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblClients = await _context.tblClients.FindAsync(id);
            _context.tblClients.Remove(tblClients);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblClientsExists(int id)
        {
            return _context.tblClients.Any(e => e.id == id);
        }
    }
}
