﻿using System;
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
            var zoodatabaseContext = _context.Main.Include(m => m.Idindiv).Include(m => m.IdzooNavigation);
            return View(await zoodatabaseContext.ToListAsync());
        }

        // GET: Mains/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var main = await _context.Main
                .Include(m => m.Idindiv)
                .Include(m => m.IdzooNavigation)
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
            ViewData["Idindivid"] = new SelectList(_context.Individ, "Id", "Bio");
            ViewData["Idzoo"] = new SelectList(_context.ZooInfo, "Id", "Details");
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
            ViewData["Idindivid"] = new SelectList(_context.Individ, "Id", "Bio", main.Idindivid);
            ViewData["Idzoo"] = new SelectList(_context.ZooInfo, "Id", "Details", main.Idzoo);
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
            ViewData["Idindivid"] = new SelectList(_context.Individ, "Id", "Bio", main.Idindivid);
            ViewData["Idzoo"] = new SelectList(_context.ZooInfo, "Id", "Details", main.Idzoo);
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
            ViewData["Idindivid"] = new SelectList(_context.Individ, "Id", "Bio", main.Idindivid);
            ViewData["Idzoo"] = new SelectList(_context.ZooInfo, "Id", "Details", main.Idzoo);
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
                .Include(m => m.Idindiv)
                .Include(m => m.IdzooNavigation)
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
