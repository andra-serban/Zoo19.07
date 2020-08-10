using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo19._07.Controllers
{
    public class IndividsController : Controller
    {
        private readonly ZooContext _context;

        public IndividsController(ZooContext context)
        {
            _context = context;
        }

        // GET: Individs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Individ.ToListAsync());
        }

        // GET: Individs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individ = await _context.Individ
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individ == null)
            {
                return NotFound();
            }

            return View(individ);
        }

        // GET: Individs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Individs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idanimal,Nume,Bio")] Individ individ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(individ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(individ);
        }

        // GET: Individs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individ = await _context.Individ.FindAsync(id);
            if (individ == null)
            {
                return NotFound();
            }
            return View(individ);
        }

        // POST: Individs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idanimal,Nume,Bio")] Individ individ)
        {
            if (id != individ.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IndividExists(individ.Id))
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
            return View(individ);
        }

        // GET: Individs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individ = await _context.Individ
                .FirstOrDefaultAsync(m => m.Id == id);
            if (individ == null)
            {
                return NotFound();
            }

            return View(individ);
        }

        // POST: Individs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var individ = await _context.Individ.FindAsync(id);
            _context.Individ.Remove(individ);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IndividExists(int id)
        {
            return _context.Individ.Any(e => e.Id == id);
        }
    }
}
