using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zoo19._07.BlobHelper;
using Zoo19._07.Models;

namespace Zoo19._07.Controllers
{
    public class IndividImagesController : Controller
    {
        private readonly zoodatabaseContext _context;

        public IndividImagesController(zoodatabaseContext context)
        {
            _context = context;
        }

        // GET: IndividImages
        public async Task<IActionResult> Index()
        {
            return View(await _context.IndividImages.ToListAsync());
        }

        // GET: IndividImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individImages = await _context.IndividImages
                .FirstOrDefaultAsync(m => m.Idindivid == id);
            if (individImages == null)
            {
                return NotFound();
            }

            return View(individImages);
        }

        // GET: IndividImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IndividImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idindivid,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9,Image10,Description")] IndividImages individImages)
        {
            BlobUpload blob = new BlobUpload();
            if (individImages.Image1 != null) individImages.Image1 = await blob.uploadToBlobAsync(individImages.Image1);
            if (individImages.Image2 != null) individImages.Image2 = await blob.uploadToBlobAsync(individImages.Image2);
            if (individImages.Image3 != null) individImages.Image3 = await blob.uploadToBlobAsync(individImages.Image3);
            if (individImages.Image4 != null) individImages.Image4 = await blob.uploadToBlobAsync(individImages.Image4);
            if (individImages.Image5 != null) individImages.Image5 = await blob.uploadToBlobAsync(individImages.Image5);
            if (individImages.Image6 != null) individImages.Image6 = await blob.uploadToBlobAsync(individImages.Image6);
            if (individImages.Image7 != null) individImages.Image7 = await blob.uploadToBlobAsync(individImages.Image7);
            if (individImages.Image8 != null) individImages.Image8 = await blob.uploadToBlobAsync(individImages.Image8);
            if (individImages.Image9 != null) individImages.Image9 = await blob.uploadToBlobAsync(individImages.Image9);
            if (individImages.Image10 != null) individImages.Image10 = await blob.uploadToBlobAsync(individImages.Image10);

            if (ModelState.IsValid)
            {
                _context.Add(individImages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(individImages);
        }

        // GET: IndividImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individImages = await _context.IndividImages.FindAsync(id);
            if (individImages == null)
            {
                return NotFound();
            }
            return View(individImages);
        }

        // POST: IndividImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idindivid,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9,Image10,Description")] IndividImages individImages)
        {
            if (id != individImages.Idindivid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individImages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividImagesExists(individImages.Idindivid))
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
            return View(individImages);
        }

        // GET: IndividImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individImages = await _context.IndividImages
                .FirstOrDefaultAsync(m => m.Idindivid == id);
            if (individImages == null)
            {
                return NotFound();
            }

            return View(individImages);
        }

        // POST: IndividImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var individImages = await _context.IndividImages.FindAsync(id);
            _context.IndividImages.Remove(individImages);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndividImagesExists(int id)
        {
            return _context.IndividImages.Any(e => e.Idindivid == id);
        }
    }
}
