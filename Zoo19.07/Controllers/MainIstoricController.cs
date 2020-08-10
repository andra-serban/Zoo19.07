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
    public class MainIstoricController : Controller
    {
        private readonly ZooContext _context;

        public MainIstoricController(ZooContext context)
        {
            _context = context;
        }

        // GET: MainIstoric
        public async Task<IActionResult> Index()
        {
            return View(await _context.MainIstoric.ToListAsync());
        }

        // GET: MainIstoric/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainIstoric = await _context.MainIstoric
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainIstoric == null)
            {
                return NotFound();
            }

            return View(mainIstoric);
        }

        // GET: MainIstoric/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MainIstoric/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ancora,Idindivid,Idzoo,Data")] MainIstoric mainIstoric)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainIstoric);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mainIstoric);
        }

        // GET: MainIstoric/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainIstoric = await _context.MainIstoric.FindAsync(id);
            if (mainIstoric == null)
            {
                return NotFound();
            }
            return View(mainIstoric);
        }

        // POST: MainIstoric/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ancora,Idindivid,Idzoo,Data")] MainIstoric mainIstoric)
        {
            if (id != mainIstoric.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainIstoric);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainIstoricExists(mainIstoric.Id))
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
            return View(mainIstoric);
        }

        // GET: MainIstoric/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainIstoric = await _context.MainIstoric
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mainIstoric == null)
            {
                return NotFound();
            }

            return View(mainIstoric);
        }

        // POST: MainIstoric/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainIstoric = await _context.MainIstoric.FindAsync(id);
            _context.MainIstoric.Remove(mainIstoric);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainIstoricExists(int id)
        {
            return _context.MainIstoric.Any(e => e.Id == id);
        }
    }
}
