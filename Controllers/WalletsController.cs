using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;

namespace Octopus.Controllers
{
    public class WalletsController : Controller
    {
       /* private readonly ApplicationDbContext _context;
        public const string SessionKeyName = "UserData";

        public WalletsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wallets
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetString(SessionKeyName);
            if (userId != null) {
                var userWallet = await _context.Wallets.Where(s=>s.UserId == userId).Include(w => w.User).ToListAsync();
                if (userWallet.Count()>0)
                {
                    return View(userWallet);
                }
                else {
                    return RedirectToAction(nameof(Create));
                }
                
            }
            return View();
           
        }

        // GET: Wallets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallets
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wallet == null)
            {
                return NotFound();
            }

            return View(wallet);
        }
        public async Task<IActionResult> CrearUnWallet(string userId = "")
        {
            HttpContext.Session.SetString(SessionKeyName, userId);
            if (userId != null)
            {
                var userWallet = await _context.Wallets.Where(s => s.UserId == userId).Include(w => w.User).FirstOrDefaultAsync();
                if (userWallet != null)
                {
                    return RedirectToAction(nameof(Edit),new { userWallet.Id });
                }
                else
                {
                    return RedirectToAction(nameof(Create));
                }

            }
            return RedirectToAction(nameof(Create));
            //  return View();
        }
        // GET: Wallets/Create
        public async Task<IActionResult> CreateAsync()
        {
            var userId = HttpContext.Session.GetString(SessionKeyName);
            var user = await _context.User.Where(s => s.Id == userId).AsNoTracking().FirstOrDefaultAsync();
            ViewBag.user = user;
           // ViewData["UserId"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: Wallets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SaldoTAE,SaldoNormal,UserId,ComisionTAE")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wallet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User, "Id", "Id", wallet.UserId);
            return View(wallet);
        }

        // GET: Wallets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallets.Include(s=>s.User).FirstOrDefaultAsync(i => i.Id == id); 
            if (wallet == null)
            {
                return NotFound();
            }
           
            return View(wallet);
        }

        // POST: Wallets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SaldoTAE,SaldoNormal,UserId,ComisionTAE")] Wallet wallet)
        {
            if (id != wallet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wallet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletExists(wallet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index","Users");
            }
          
            return View(wallet);
        }

        // GET: Wallets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallets
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wallet == null)
            {
                return NotFound();
            }

            return View(wallet);
        }

        // POST: Wallets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wallet = await _context.Wallets.FindAsync(id);
            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalletExists(int id)
        {
            return _context.Wallets.Any(e => e.Id == id);
        }

    */
    }
}
