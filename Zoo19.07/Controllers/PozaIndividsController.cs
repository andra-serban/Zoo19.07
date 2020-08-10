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
    public class PozaIndividsController : Controller
    {
        private readonly ZooContext _context;

        public PozaIndividsController(ZooContext context)
        {
            _context = context;
        }

        // GET: PozaIndivids
        public async Task<IActionResult> Index()
        {
            return View(await _context.PozaIndivid.ToListAsync());
        }

        // GET: PozaIndivids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozaIndivid = await _context.PozaIndivid
                .FirstOrDefaultAsync(m => m.Idindivid == id);
            if (pozaIndivid == null)
            {
                return NotFound();
            }

            return View(pozaIndivid);
        }

        // GET: PozaIndivids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PozaIndivids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idindivid,Descriere,Poza1,Poza2,Poza3,Poza4,Poza5,Poza6,Poza7,Poza8,Poza9,Poza10")] PozaIndivid pozaIndivid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozaIndivid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozaIndivid);
        }

        // GET: PozaIndivids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozaIndivid = await _context.PozaIndivid.FindAsync(id);
            if (pozaIndivid == null)
            {
                return NotFound();
            }
            return View(pozaIndivid);
        }

        // POST: PozaIndivids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idindivid,Descriere,Poza1,Poza2,Poza3,Poza4,Poza5,Poza6,Poza7,Poza8,Poza9,Poza10")] PozaIndivid pozaIndivid)
        {
            if (id != pozaIndivid.Idindivid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozaIndivid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozaIndividExists(pozaIndivid.Idindivid))
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
            return View(pozaIndivid);
        }

        // GET: PozaIndivids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozaIndivid = await _context.PozaIndivid
                .FirstOrDefaultAsync(m => m.Idindivid == id);
            if (pozaIndivid == null)
            {
                return NotFound();
            }

            return View(pozaIndivid);
        }

        // POST: PozaIndivids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pozaIndivid = await _context.PozaIndivid.FindAsync(id);
            _context.PozaIndivid.Remove(pozaIndivid);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozaIndividExists(int id)
        {
            return _context.PozaIndivid.Any(e => e.Idindivid == id);
        }
    }
}
