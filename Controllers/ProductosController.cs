using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Octopus.Data;
using Octopus.Models;
using Octopus.Services;

namespace Octopus.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserData _userData;
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;

        public ProductosController(ApplicationDbContext context,
            SignInManager<User> SignInManager,
            UserManager<User> UserManager)
        {
            _context = context;
            _SignInManager = SignInManager;
            _UserManager = UserManager;
            _userData = new UserData(_context, _SignInManager, _UserManager);
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            User currentUser = await _userData.GetCurrentUserId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (currentUser != null) {
                Grupo grupoUser = await _context.Grupos.AsNoTracking().FirstOrDefaultAsync(s => s.OwnerId == currentUser.Id);
                var applicationDbContext = _context.Productos.Include(p => p.Grupo)
                    .Where(s=>s.GrupoId == grupoUser.Id).Include(p => p.PType).AsNoTracking();
                return View(await applicationDbContext.ToListAsync());
            }
            return View();
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Grupo)
                .Include(p => p.PType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public async Task<IActionResult> CreateAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Grupo grupo = await _context.Grupos.AsNoTracking().FirstOrDefaultAsync(s => s.OwnerId == userId);
            ViewBag.userId = grupo.Id;
            ViewData["FolderId"] = new SelectList(_context.Folders
                .Where(s=>s.UserOwner == userId || s.FolderName == "General").AsNoTracking().OrderBy(s=>s.Id), "Id", "FolderName");
            ViewData["PTypeId"] = new SelectList(_context.PTypes, "Id", "TypeName");
            return PartialView();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,PTypeId,GrupoId,CarpetaId")] Producto producto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                producto.DateCreated = DateTime.Now;
                producto.Hastags = producto.ProductName.Replace(" ", ",");
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Edit),new { id = producto.Id});
            }
            ViewBag.userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["FolderId"] = new SelectList(_context.Folders
                 .Where(s => s.UserOwner == userId || s.FolderName == "General").AsNoTracking().OrderBy(s => s.Id), "Id", "FolderName");
            ViewData["PTypeId"] = new SelectList(_context.PTypes, "Id", "TypeName", producto.PTypeId);
            return PartialView(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id, bool partial = true)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.Where(s=>s.Id == id).Include(s=>s.PType).FirstOrDefaultAsync();
            if (producto == null)
            {
                return NotFound();
            }
            ViewBag.TypeName = producto.PType.TypeName;

            return PartialView(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Stock,Ventas,Description,Codigo,Hastags,DateCreated,Thumbnail,PTypeId,GrupoId")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Id))
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
            ViewData["GrupoId"] = new SelectList(_context.Grupos, "Id", "GroupName", producto.GrupoId);
            ViewData["PTypeId"] = new SelectList(_context.PTypes, "Id", "Id", producto.PTypeId);
            return PartialView(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Grupo)
                .Include(p => p.PType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (producto == null)
            {
                return NotFound();
            }

            return PartialView(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.Id == id);
        }
    }
}
