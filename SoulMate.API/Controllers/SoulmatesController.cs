using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoulMate.API.data;

namespace SoulMate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoulmatesController : ControllerBase
    {
        private readonly SoulmateDbContext _context;

        public SoulmatesController(SoulmateDbContext context)
        {
            _context = context;
        }

        // GET: api/Soulmates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Soulmate>>> GetSoulmate()
        {
            return await _context.Soulmate.ToListAsync();
        }

        // GET: api/Soulmates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Soulmate>> GetSoulmate(int id)
        {
            var soulmate = await _context.Soulmate.FindAsync(id);

            if (soulmate == null)
            {
                return NotFound();
            }

            return soulmate;
        }

        // PUT: api/Soulmates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoulmate(int id, Soulmate soulmate)
        {
            if (id != soulmate.Id)
            {
                return BadRequest();
            }

            _context.Entry(soulmate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoulmateExists(id))
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

        // POST: api/Soulmates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Soulmate>> PostSoulmate(Soulmate soulmate)
        {
            _context.Soulmate.Add(soulmate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoulmate", new { id = soulmate.Id }, soulmate);
        }

        // DELETE: api/Soulmates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoulmate(int id)
        {
            var soulmate = await _context.Soulmate.FindAsync(id);
            if (soulmate == null)
            {
                return NotFound();
            }

            _context.Soulmate.Remove(soulmate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoulmateExists(int id)
        {
            return _context.Soulmate.Any(e => e.Id == id);
        }
    }
}
