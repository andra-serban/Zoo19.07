
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
    public class IndividsApiController : ControllerBase
    {
        private readonly zoodatabaseContext _context;

        public IndividsApiController(zoodatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Individs1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Individ>>> GetIndivid()
        {
            return await _context.Individ.ToListAsync();
        }

        // GET: api/Individs1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Individ>> GetIndivid(int id)
        {
            var individ = await _context.Individ.FindAsync(id);

            if (individ == null)
            {
                return NotFound();
            }

            return individ;
        }

        // PUT: api/Individs1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndivid(int id, Individ individ)
        {
            if (id != individ.Id)
            {
                return BadRequest();
            }

            _context.Entry(individ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividExists(id))
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

        // POST: api/Individs1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Individ>> PostIndivid(Individ individ)
        {
            _context.Individ.Add(individ);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IndividExists(individ.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIndivid", new { id = individ.Id }, individ);
        }

        // DELETE: api/Individs1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Individ>> DeleteIndivid(int id)
        {
            var individ = await _context.Individ.FindAsync(id);
            if (individ == null)
            {
                return NotFound();
            }

            _context.Individ.Remove(individ);
            await _context.SaveChangesAsync();

            return individ;
        }

        private bool IndividExists(int id)
        {
            return _context.Individ.Any(e => e.Id == id);
        }
    }
}
