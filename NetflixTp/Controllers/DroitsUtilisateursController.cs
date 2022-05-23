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
    public class DroitsUtilisateursController : ControllerBase
    {
        private readonly masterContext _context;

        public DroitsUtilisateursController(masterContext context)
        {
            _context = context;
        }

        // GET: api/DroitsUtilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DroitsUtilisateur>>> GetDroitsUtilisateurs()
        {
            return await _context.DroitsUtilisateurs.ToListAsync();
        }

        // GET: api/DroitsUtilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DroitsUtilisateur>> GetDroitsUtilisateur(int id)
        {
            var droitsUtilisateur = await _context.DroitsUtilisateurs.FindAsync(id);

            if (droitsUtilisateur == null)
            {
                return NotFound();
            }

            return droitsUtilisateur;
        }

        // PUT: api/DroitsUtilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDroitsUtilisateur(int id, DroitsUtilisateur droitsUtilisateur)
        {
            if (id != droitsUtilisateur.IdDroitsUtilisateurs)
            {
                return BadRequest();
            }

            _context.Entry(droitsUtilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DroitsUtilisateurExists(id))
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

        // POST: api/DroitsUtilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DroitsUtilisateur>> PostDroitsUtilisateur(DroitsUtilisateur droitsUtilisateur)
        {
            _context.DroitsUtilisateurs.Add(droitsUtilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDroitsUtilisateur", new { id = droitsUtilisateur.IdDroitsUtilisateurs }, droitsUtilisateur);
        }

        // DELETE: api/DroitsUtilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDroitsUtilisateur(int id)
        {
            var droitsUtilisateur = await _context.DroitsUtilisateurs.FindAsync(id);
            if (droitsUtilisateur == null)
            {
                return NotFound();
            }

            _context.DroitsUtilisateurs.Remove(droitsUtilisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DroitsUtilisateurExists(int id)
        {
            return _context.DroitsUtilisateurs.Any(e => e.IdDroitsUtilisateurs == id);
        }
    }
}
