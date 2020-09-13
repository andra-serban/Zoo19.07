using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zoo19._07.Models;

namespace Zoo19._07.Controllers
{
    public class MainsController : Controller
    {
        private readonly zoodatabaseContext _context;

        public MainsController(zoodatabaseContext context)
        {
            _context = context;
        }

        // GET: Mains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Main.ToListAsync());
        }

        // GET: Mains/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Main
                .FirstOrDefaultAsync(m => m.Anchor == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // GET: Mains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Anchor,Idindivid,Idzoo")] Main main)
        {
            if (ModelState.IsValid)
            {
                _context.Add(main);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(main);
        }

        // GET: Mains/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Main.FindAsync(id);
            if (main == null)
            {
                return NotFound();
            }
            return View(main);
        }

        // POST: Mains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Anchor,Idindivid,Idzoo")] Main main)
        {
            if (id != main.Anchor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(main);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainExists(main.Anchor))
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
            return View(main);
        }

        // GET: Mains/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Main
                .FirstOrDefaultAsync(m => m.Anchor == id);
            if (main == null)
            {
                return NotFound();
            }

            return View(main);
        }

        // POST: Mains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var main = await _context.Main.FindAsync(id);
            _context.Main.Remove(main);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainExists(string id)
        {
            return _context.Main.Any(e => e.Anchor == id);
        }
    }
}
