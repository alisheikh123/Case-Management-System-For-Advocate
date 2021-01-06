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
    public class tblCasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblCases
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.tblCases.Include(t => t.TblClients).Include(t => t.TblcaseCategory).Include(t => t.Tblcourt);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: tblCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCases = await _context.tblCases
                .Include(t => t.TblClients)
                .Include(t => t.TblcaseCategory)
                .Include(t => t.Tblcourt)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblCases == null)
            {
                return NotFound();
            }

            return View(tblCases);
        }

        // GET: tblCases/Create
        public IActionResult Create()
        {
            
             string caseno = "001";
           var casecount =_context.tblCases.Count();//2
            var itemscase = casecount - 1;//2-1
             
            var checkcasecode = _context.tblCases.Where(x => x.CaseNo == caseno).Count();
            if (checkcasecode > 0)
            {
                int casen = int.Parse(caseno);
                casen = casen + 1;
                string cn = "00" + casen.ToString();
                ViewData["caseno"] = cn;

            }
            else
            {
                ViewData["caseno"] = caseno;
            }
            ViewData["ClientId"] = new SelectList(_context.Set<tblClients>(), "id", "Name");
            ViewData["CaseCatgoryid"] = new SelectList(_context.tblcaseCategory, "id", "Categoryname");
            ViewData["courtid"] = new SelectList(_context.Set<tblcourt>(), "id", "Courtname");
            return View();
        }

        // POST: tblCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,CaseCatgoryid,CaseNo,Type,Title,ClientId,courtid,oppositeName,dateInstitution,File")] tblCases tblCases)
        {
            if (ModelState.IsValid)
            {
                var checkcaseNo = _context.tblCases.Where(x => x.CaseNo == tblCases.CaseNo).Count();
                if (checkcaseNo>0)
                  {
                    return NotFound();
                  }
                _context.Add(tblCases);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Set<tblClients>(), "id", "Name", tblCases.ClientId);
            ViewData["CaseCatgoryid"] = new SelectList(_context.tblcaseCategory, "id", "Categoryname", tblCases.CaseCatgoryid);
            ViewData["courtid"] = new SelectList(_context.Set<tblcourt>(), "id", "Courtname", tblCases.courtid);
            return View(tblCases);
        }

        // GET: tblCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCases = await _context.tblCases.FindAsync(id);
            if (tblCases == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Set<tblClients>(), "id", "id", tblCases.ClientId);
            ViewData["CaseCatgoryid"] = new SelectList(_context.tblcaseCategory, "id", "id", tblCases.CaseCatgoryid);
            ViewData["courtid"] = new SelectList(_context.Set<tblcourt>(), "id", "id", tblCases.courtid);
            return View(tblCases);
        }

        // POST: tblCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,CaseCatgoryid,CaseNo,Type,Title,ClientId,courtid,oppositeName,dateInstitution,File")] tblCases tblCases)
        {
            if (id != tblCases.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCasesExists(tblCases.id))
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
            ViewData["ClientId"] = new SelectList(_context.Set<tblClients>(), "id", "id", tblCases.ClientId);
            ViewData["CaseCatgoryid"] = new SelectList(_context.tblcaseCategory, "id", "id", tblCases.CaseCatgoryid);
            ViewData["courtid"] = new SelectList(_context.Set<tblcourt>(), "id", "id", tblCases.courtid);
            return View(tblCases);
        }

        // GET: tblCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCases = await _context.tblCases
                .Include(t => t.TblClients)
                .Include(t => t.TblcaseCategory)
                .Include(t => t.Tblcourt)
                .FirstOrDefaultAsync(m => m.id == id);
            if (tblCases == null)
            {
                return NotFound();
            }

            return View(tblCases);
        }

        // POST: tblCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCases = await _context.tblCases.FindAsync(id);
            _context.tblCases.Remove(tblCases);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCasesExists(int id)
        {
            return _context.tblCases.Any(e => e.id == id);
        }
    }
}
