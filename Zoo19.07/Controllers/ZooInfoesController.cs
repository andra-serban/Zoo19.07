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
    public class ZooInfoesController : Controller
    {
        private readonly ZooContext _context;

        public ZooInfoesController(ZooContext context)
        {
            _context = context;
        }

        // GET: ZooInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ZooInfo.ToListAsync());
        }

        // GET: ZooInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooInfo = await _context.ZooInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zooInfo == null)
            {
                return NotFound();
            }

            return View(zooInfo);
        }

        // GET: ZooInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ZooInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume,Detalii")] ZooInfo zooInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zooInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zooInfo);
        }

        // GET: ZooInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooInfo = await _context.ZooInfo.FindAsync(id);
            if (zooInfo == null)
            {
                return NotFound();
            }
            return View(zooInfo);
        }

        // POST: ZooInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume,Detalii")] ZooInfo zooInfo)
        {
            if (id != zooInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zooInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZooInfoExists(zooInfo.Id))
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
            return View(zooInfo);
        }

        // GET: ZooInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zooInfo = await _context.ZooInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zooInfo == null)
            {
                return NotFound();
            }

            return View(zooInfo);
        }

        // POST: ZooInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zooInfo = await _context.ZooInfo.FindAsync(id);
            _context.ZooInfo.Remove(zooInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZooInfoExists(int id)
        {
            return _context.ZooInfo.Any(e => e.Id == id);
        }
    }
}
