using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetflixTp.Models;

namespace NetflixTp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaisonsController : ControllerBase
    {
        private readonly masterContext _context;

        public SaisonsController(masterContext context)
        {
            _context = context;
        }

        // GET: api/Saisons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Saison>>> GetSaisons()
        {
            return await _context.Saisons.ToListAsync();
        }

        // GET: api/Saisons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Saison>> GetSaison(int id)
        {
            var saison = await _context.Saisons.FindAsync(id);

            if (saison == null)
            {
                return NotFound();
            }

            return saison;
        }

        // PUT: api/Saisons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaison(int id, Saison saison)
        {
            if (id != saison.IdSaison)
            {
                return BadRequest();
            }

            _context.Entry(saison).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaisonExists(id))
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

        // POST: api/Saisons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Saison>> PostSaison(Saison saison)
        {
            _context.Saisons.Add(saison);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaison", new { id = saison.IdSaison }, saison);
        }

        // DELETE: api/Saisons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaison(int id)
        {
            var saison = await _context.Saisons.FindAsync(id);
            if (saison == null)
            {
                return NotFound();
            }

            _context.Saisons.Remove(saison);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaisonExists(int id)
        {
            return _context.Saisons.Any(e => e.IdSaison == id);
        }
    }
}
