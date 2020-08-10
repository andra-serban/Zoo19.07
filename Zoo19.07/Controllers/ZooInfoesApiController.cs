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
    public class ZooInfoesApiController : ControllerBase
    {
        private readonly ZooContext _context;

        public ZooInfoesApiController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/ZooInfoesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZooInfo>>> GetZoo()
        {
            return await _context.ZooInfo.ToListAsync();
        }

        // GET: api/ZooInfoesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZooInfo>> GetZooInfo(int id)
        {
            var zooInfo = await _context.ZooInfo.FindAsync(id);

            if (zooInfo == null)
            {
                return NotFound();
            }

            return zooInfo;
        }

        // PUT: api/ZooInfoesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZooInfo(int id, ZooInfo zooInfo)
        {
            if (id != zooInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(zooInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooInfoExists(id))
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

        // POST: api/ZooInfoesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ZooInfo>> PostZooInfo(ZooInfo zooInfo)
        {
            _context.ZooInfo.Add(zooInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZooInfoExists(zooInfo.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZooInfo", new { id = zooInfo.Id }, zooInfo);
        }

        // DELETE: api/ZooInfoesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ZooInfo>> DeleteZooInfo(int id)
        {
            var zooInfo = await _context.ZooInfo.FindAsync(id);
            if (zooInfo == null)
            {
                return NotFound();
            }

            _context.ZooInfo.Remove(zooInfo);
            await _context.SaveChangesAsync();

            return zooInfo;
        }

        private bool ZooInfoExists(int id)
        {
            return _context.ZooInfo.Any(e => e.Id == id);
        }
    }
}
