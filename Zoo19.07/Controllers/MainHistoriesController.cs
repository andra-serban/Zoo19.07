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
    public class MainHistoriesController : Controller
    {
        private readonly zoodatabaseContext _context;

        public MainHistoriesController(zoodatabaseContext context)
        {
            _context = context;
        }

        // GET: MainHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.MainHistory.ToListAsync());
        }

        // GET: MainHistories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainHistory = await _context.MainHistory
                .FirstOrDefaultAsync(m => m.Anchor == id);
            if (mainHistory == null)
            {
                return NotFound();
            }

            return View(mainHistory);
        }

        // GET: MainHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Anchor,Idindivid,IdZoo,Data")] MainHistory mainHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainHistory);
        }

        // GET: MainHistories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainHistory = await _context.MainHistory.FindAsync(id);
            if (mainHistory == null)
            {
                return NotFound();
            }
            return View(mainHistory);
        }

        // POST: MainHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Anchor,Idindivid,IdZoo,Data")] MainHistory mainHistory)
        {
            if (id != mainHistory.Anchor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainHistoryExists(mainHistory.Anchor))
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
            return View(mainHistory);
        }

        // GET: MainHistories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainHistory = await _context.MainHistory
                .FirstOrDefaultAsync(m => m.Anchor == id);
            if (mainHistory == null)
            {
                return NotFound();
            }

            return View(mainHistory);
        }

        // POST: MainHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mainHistory = await _context.MainHistory.FindAsync(id);
            _context.MainHistory.Remove(mainHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainHistoryExists(string id)
        {
            return _context.MainHistory.Any(e => e.Anchor == id);
        }
    }
}
