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
    public class IndividImagesApiController : ControllerBase
    {
        private readonly zoodatabaseContext _context;

        public IndividImagesApiController(zoodatabaseContext context)
        {
            _context = context;
        }

        // GET: api/IndividImagesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividImages>>> GetIndividImages()
        {
            return await _context.IndividImages.ToListAsync();
        }

        // GET: api/IndividImagesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IndividImages>> GetIndividImages(int id)
        {
            var individImages = await _context.IndividImages.FindAsync(id);

            if (individImages == null)
            {
                return NotFound();
            }

            return individImages;
        }

        // PUT: api/IndividImagesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndividImages(int id, IndividImages individImages)
        {
            if (id != individImages.Idindivid)
            {
                return BadRequest();
            }

            _context.Entry(individImages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividImagesExists(id))
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

        // POST: api/IndividImagesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IndividImages>> PostIndividImages(IndividImages individImages)
        {
            _context.IndividImages.Add(individImages);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (IndividImagesExists(individImages.Idindivid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetIndividImages", new { id = individImages.Idindivid }, individImages);
        }

        // DELETE: api/IndividImagesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IndividImages>> DeleteIndividImages(int id)
        {
            var individImages = await _context.IndividImages.FindAsync(id);
            if (individImages == null)
            {
                return NotFound();
            }

            _context.IndividImages.Remove(individImages);
            await _context.SaveChangesAsync();

            return individImages;
        }

        private bool IndividImagesExists(int id)
        {
            return _context.IndividImages.Any(e => e.Idindivid == id);
        }
    }
}
