using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;

namespace Octopus.Controllers
{
    public class LadasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LadasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ladas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ladas.Include(l => l.Region).AsNoTracking().OrderBy(s => s.RegionId).Skip(0).Take(10);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ladas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lada = await _context.Ladas
                .Include(l => l.Region).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lada == null)
            {
                return NotFound();
            }

            return View(lada);
        }

        // GET: Ladas/Create
        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_context.Regions.AsNoTracking(), "Id", "RegionName");
            return View();
        }

        // POST: Ladas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LadaName,RegionId")] Lada lada)
        {
            if (ModelState.IsValid)
            {
               // _context.AddRange(ladasInit);
                _context.Add(lada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Regions.AsNoTracking(), "Id", "RegionName", lada.RegionId);
            return View(lada);
        }

        // GET: Ladas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lada = await _context.Ladas.FindAsync(id);
            if (lada == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Regions.AsNoTracking(), "Id", "RegionName", lada.RegionId);
            return View(lada);
        }

        // POST: Ladas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LadaName,RegionId")] Lada lada)
        {
            if (id != lada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LadaExists(lada.Id))
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
            ViewData["RegionId"] = new SelectList(_context.Regions.AsNoTracking(), "Id", "RegionName", lada.RegionId);
            return View(lada);
        }

        // GET: Ladas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lada = await _context.Ladas
                .Include(l => l.Region).AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lada == null)
            {
                return NotFound();
            }

            return View(lada);
        }

        // POST: Ladas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lada = await _context.Ladas.FindAsync(id);
            _context.Ladas.Remove(lada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LadaExists(int id)
        {
            return _context.Ladas.Any(e => e.Id == id);
        }
       
    }
}
