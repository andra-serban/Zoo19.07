using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zoo19._07.Models;

namespace Zoo19._07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainHistoriesApiController : ControllerBase
    {
        private readonly zoodatabaseContext _context;

        public MainHistoriesApiController(zoodatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MainHistoriesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainHistory>>> GetMainHistory()
        {
            return await _context.MainHistory.ToListAsync();
        }

        // GET: api/MainHistoriesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainHistory>> GetMainHistory(string id)
        {
            var mainHistory = await _context.MainHistory.FindAsync(id);

            if (mainHistory == null)
            {
                return NotFound();
            }

            return mainHistory;
        }

        // PUT: api/MainHistoriesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainHistory(string id, MainHistory mainHistory)
        {
            if (id != mainHistory.Anchor)
            {
                return BadRequest();
            }

            _context.Entry(mainHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainHistoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MainHistoriesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MainHistory>> PostMainHistory(MainHistory mainHistory)
        {
            _context.MainHistory.Add(mainHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MainHistoryExists(mainHistory.Anchor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMainHistory", new { id = mainHistory.Anchor }, mainHistory);
        }

        // DELETE: api/MainHistoriesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MainHistory>> DeleteMainHistory(string id)
        {
            var mainHistory = await _context.MainHistory.FindAsync(id);
            if (mainHistory == null)
            {
                return NotFound();
            }

            _context.MainHistory.Remove(mainHistory);
            await _context.SaveChangesAsync();

            return mainHistory;
        }

        private bool MainHistoryExists(string id)
        {
            return _context.MainHistory.Any(e => e.Anchor == id);
        }
    }
}
