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
    public class MainsApiController : ControllerBase
    {
        private readonly zoodatabaseContext _context;

        public MainsApiController(zoodatabaseContext context)
        {
            _context = context;
        }

        // GET: api/MainsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Main>>> GetMain()
        {
            return await _context.Main.ToListAsync();
        }

        // GET: api/MainsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Main>> GetMain(string id)
        {
            var main = await _context.Main.FindAsync(id);

            if (main == null)
            {
                return NotFound();
            }

            return main;
        }

        // PUT: api/MainsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMain(string id, Main main)
        {
            if (id != main.Anchor)
            {
                return BadRequest();
            }

            _context.Entry(main).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainExists(id))
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

        // POST: api/MainsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Main>> PostMain(Main main)
        {
            _context.Main.Add(main);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MainExists(main.Anchor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMain", new { id = main.Anchor }, main);
        }

        // DELETE: api/MainsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Main>> DeleteMain(string id)
        {
            var main = await _context.Main.FindAsync(id);
            if (main == null)
            {
                return NotFound();
            }

            _context.Main.Remove(main);
            await _context.SaveChangesAsync();

            return main;
        }

        private bool MainExists(string id)
        {
            return _context.Main.Any(e => e.Anchor == id);
        }
    }
}
