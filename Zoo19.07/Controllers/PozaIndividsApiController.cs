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
    public class PozaIndividsApiController : ControllerBase
    {
        private readonly ZooContext _context;

        public PozaIndividsApiController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/PozaIndividsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PozaIndivid>>> GetPozaIndivid()
        {
            return await _context.PozaIndivid.ToListAsync();
        }

        // GET: api/PozaIndividsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PozaIndivid>> GetPozaIndivid(int id)
        {
            var pozaIndivid = await _context.PozaIndivid.FindAsync(id);

            if (pozaIndivid == null)
            {
                return NotFound();
            }

            return pozaIndivid;
        }

        // PUT: api/PozaIndividsApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPozaIndivid(int id, PozaIndivid pozaIndivid)
        {
            if (id != pozaIndivid.Idindivid)
            {
                return BadRequest();
            }

            _context.Entry(pozaIndivid).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PozaIndividExists(id))
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

        // POST: api/PozaIndividsApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PozaIndivid>> PostPozaIndivid(PozaIndivid pozaIndivid)
        {
            _context.PozaIndivid.Add(pozaIndivid);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PozaIndividExists(pozaIndivid.Idindivid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPozaIndivid", new { id = pozaIndivid.Idindivid }, pozaIndivid);
        }

        // DELETE: api/PozaIndividsApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PozaIndivid>> DeletePozaIndivid(int id)
        {
            var pozaIndivid = await _context.PozaIndivid.FindAsync(id);
            if (pozaIndivid == null)
            {
                return NotFound();
            }

            _context.PozaIndivid.Remove(pozaIndivid);
            await _context.SaveChangesAsync();

            return pozaIndivid;
        }

        private bool PozaIndividExists(int id)
        {
            return _context.PozaIndivid.Any(e => e.Idindivid == id);
        }
    }
}
