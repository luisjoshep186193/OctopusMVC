using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Helpers;
using Octopus.Models;

namespace Octopus.Controllers
{
    [Authorize]
    public class CarteraTransactions : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;
        private PaginadorGenerico<CarteraTransaction> _PaginadorTransactions;
        private readonly int _RegistrosPorPagina = 20;

        public CarteraTransactions(ApplicationDbContext context,
            SignInManager<User> SignInManager,
            UserManager<User> UserManager)
        {
            _context = context;
            _SignInManager = SignInManager;
            _UserManager = UserManager;
        }

        // GET: CarteraTransactions
        public async Task<IActionResult> Index(string id = "", bool partial = false, string datInit = "", string datEnd = "", int pagina = 1)
        {
            int _TotalRegistros = 0;
            IQueryable<CarteraTransaction> recargasQuery;
            if (_SignInManager.IsSignedIn(User))
            {
                DateTime dateInit = datInit == null || datInit == "" ? DateTime.Today : DateTime.Parse(datInit);
                DateTime dateEnd = datEnd == null || datEnd == "" ? DateTime.Now : DateTime.Parse(datEnd);
                PaginadorGenerico<CarteraTransaction> recargasPaged;
                if (id != null)
                {
                    if (!id.Equals("0"))
                    {
                        ViewBag.carteraId = id;

                        var cartera = await _context.Carteras.AsNoTracking().FirstOrDefaultAsync(s => s.Id == Int64.Parse(id));

                        recargasQuery = _context.CarteraTransactions.Include(c => c.Cartera)
                            .Where(s => s.CarteraId == cartera.Id && s.FechaOperation >= dateInit && s.FechaOperation <= dateEnd)
                            .AsNoTracking();

                    }
                    else
                    {
                        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        var cartera = await _context.Carteras.AsNoTracking().Where(s => s.OwnerId == userId).FirstOrDefaultAsync();
                        ViewBag.carteraId = cartera.Id;
                        var carteraUser = await _context.User.Include(s => s.Cartera).FirstOrDefaultAsync(s => s.Id == userId);
                        ViewBag.carteraId = carteraUser.CarteraId;

                        recargasQuery = _context.CarteraTransactions.Include(c => c.Cartera)
                              .Where(s => s.CarteraId == cartera.Id && s.FechaOperation >= dateInit && s.FechaOperation <= dateEnd)
                              .AsNoTracking();
                              
                    }
                    recargasPaged = (PaginadorGenerico<CarteraTransaction>)PaginadorGenerico<CarteraTransaction>.Create(recargasQuery, pagina, 0);
                    if (partial)
                        return PartialView(recargasPaged);
                    return View(recargasPaged);
                }
            }
            else
            {
                return NotFound();
            }
                return View(); 

            }

        // GET: CarteraTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteraTransaction = await _context.CarteraTransactions
                .Include(c => c.Cartera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carteraTransaction == null)
            {
                return NotFound();
            }

            return View(carteraTransaction);
        }

        // GET: CarteraTransactions/Create
        public IActionResult Create()
        {
            ViewData["CarteraId"] = new SelectList(_context.Carteras, "Id", "Id");
            return View();
        }

        // POST: CarteraTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OperacionDesc,Monto,FechaOperation,CarteraId")] CarteraTransaction carteraTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carteraTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarteraId"] = new SelectList(_context.Carteras, "Id", "Id", carteraTransaction.CarteraId);
            return View(carteraTransaction);
        }

        // GET: CarteraTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteraTransaction = await _context.CarteraTransactions.FindAsync(id);
            if (carteraTransaction == null)
            {
                return NotFound();
            }
            ViewData["CarteraId"] = new SelectList(_context.Carteras, "Id", "Id", carteraTransaction.CarteraId);
            return View(carteraTransaction);
        }

        // POST: CarteraTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OperacionDesc,Monto,FechaOperation,CarteraId")] CarteraTransaction carteraTransaction)
        {
            if (id != carteraTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carteraTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarteraTransactionExists(carteraTransaction.Id))
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
            ViewData["CarteraId"] = new SelectList(_context.Carteras, "Id", "Id", carteraTransaction.CarteraId);
            return View(carteraTransaction);
        }

        // GET: CarteraTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteraTransaction = await _context.CarteraTransactions
                .Include(c => c.Cartera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carteraTransaction == null)
            {
                return NotFound();
            }

            return View(carteraTransaction);
        }

        // POST: CarteraTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carteraTransaction = await _context.CarteraTransactions.FindAsync(id);
            _context.CarteraTransactions.Remove(carteraTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteraTransactionExists(int id)
        {
            return _context.CarteraTransactions.Any(e => e.Id == id);
        }
    }
}
