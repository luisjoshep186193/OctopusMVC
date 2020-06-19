using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Octopus.Data;
using Octopus.Models;
using ServiceLayer;

namespace Octopus.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IWebHostEnvironment env { get; }
        public IConfiguration Configuration { get; }
        private readonly UserManager<User> _UserManager;

        public ImagesController(ApplicationDbContext context,
            IWebHostEnvironment _env,
            IConfiguration configuration,
            UserManager<User> UserManager)
        {
            _UserManager = UserManager;
            _context = context;
            env = _env;
            Configuration = configuration;
        }

        // GET: Images
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Image.Include(i => i.PType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Images/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image
                .Include(i => i.PType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Images/Create
        public async Task<IActionResult> CreateAsync(int id, string typeElem)
        {
            var type = await _context.PTypes.Where(s => s.TypeName == typeElem).AsNoTracking().FirstOrDefaultAsync();
            if (type == null) {
                return NotFound();
            }
            ViewBag.typeId = type.Id;
            ViewBag.elementId = id;
            return PartialView();
        }

        // POST: Images/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageName,URL,PTypeId,AssetId,File")] Image image)
        {
            var userId = _UserManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                #region Read File Content  
                var uploads = Path.Combine(env.WebRootPath, "files");
                bool exists = Directory.Exists(uploads);
                if (!exists)
                    Directory.CreateDirectory(uploads);

                var fileName = Path.GetFileName(image.File.FileName);
                var fileStream = new FileStream(Path.Combine(uploads, image.File.FileName), FileMode.Create);
                string mimeType = image.File.ContentType;
                byte[] fileData = new byte[image.File.Length];
                //Stream stream = new MemoryStream(files[0].OpenReadStream().Read);
                //FileStream uploadFileStream = File.OpenRead(files[0].);
                Stream stream = image.File.OpenReadStream();

                BlobStorageService objBlobService = new BlobStorageService(Configuration);

                var ImagePath = objBlobService.UploadFileToBlob(image.File.FileName.Replace(" ",""), stream, mimeType, userId);
                #endregion
                image.URL = ImagePath;
                

                _context.Add(image);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit","Productos",new { id = image.PTypeId });
            }
            ViewData["PTypeId"] = new SelectList(_context.PTypes, "Id", "TypeName", image.PTypeId);
            return PartialView(image);
        }

        // GET: Images/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["PTypeId"] = new SelectList(_context.PTypes, "Id", "TypeName", image.PTypeId);
            return View(image);
        }

        // POST: Images/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageName,URL,PTypeId,AssetId")] Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.Id))
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
            ViewData["PTypeId"] = new SelectList(_context.PTypes, "Id", "Id", image.PTypeId);
            return View(image);
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Image
                .Include(i => i.PType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _context.Image.FindAsync(id);
            _context.Image.Remove(image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(int id)
        {
            return _context.Image.Any(e => e.Id == id);
        }
    }
}
