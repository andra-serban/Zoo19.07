using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zoo.Models;

namespace Zoo19._07.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainIstoricApiController : ControllerBase
    {
        private readonly ZooContext _context;

        public MainIstoricApiController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/MainIstoricsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MainIstoric>>> GetMainIstoric()
        {
            return await _context.MainIstoric.ToListAsync();
        }

        // GET: api/MainIstoricsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MainIstoric>> GetMainIstoric(int id)
        {
            var mainIstoric = await _context.MainIstoric.FindAsync(id);

            if (mainIstoric == null)
            {
                return NotFound();
            }

            return mainIstoric;
        }

        // PUT: api/MainIstoricsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMainIstoric(int id, MainIstoric mainIstoric)
        {
            if (id != mainIstoric.Id)
            {
                return BadRequest();
            }

            _context.Entry(mainIstoric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MainIstoricExists(id))
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

        // POST: api/MainIstoricsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MainIstoric>> PostMainIstoric(MainIstoric mainIstoric)
        {
            _context.MainIstoric.Add(mainIstoric);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MainIstoricExists(mainIstoric.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMainIstoric", new { id = mainIstoric.Id }, mainIstoric);
        }

        // DELETE: api/MainIstoricsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MainIstoric>> DeleteMainIstoric(int id)
        {
            var mainIstoric = await _context.MainIstoric.FindAsync(id);
            if (mainIstoric == null)
            {
                return NotFound();
            }

            _context.MainIstoric.Remove(mainIstoric);
            await _context.SaveChangesAsync();

            return mainIstoric;
        }

        private bool MainIstoricExists(int id)
        {
            return _context.MainIstoric.Any(e => e.Id == id);
        }
    }
}
