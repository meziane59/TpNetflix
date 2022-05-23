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
    public class UtilisateurProfilsController : ControllerBase
    {
        private readonly masterContext _context;

        public UtilisateurProfilsController(masterContext context)
        {
            _context = context;
        }

        // GET: api/UtilisateurProfils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UtilisateurProfil>>> GetUtilisateurProfils()
        {
            return await _context.UtilisateurProfils.ToListAsync();
        }

        // GET: api/UtilisateurProfils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UtilisateurProfil>> GetUtilisateurProfil(int id)
        {
            var utilisateurProfil = await _context.UtilisateurProfils.FindAsync(id);

            if (utilisateurProfil == null)
            {
                return NotFound();
            }

            return utilisateurProfil;
        }

        // PUT: api/UtilisateurProfils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUtilisateurProfil(int id, UtilisateurProfil utilisateurProfil)
        {
            if (id != utilisateurProfil.IdUtilisateur)
            {
                return BadRequest();
            }

            _context.Entry(utilisateurProfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UtilisateurProfilExists(id))
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

        // POST: api/UtilisateurProfils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UtilisateurProfil>> PostUtilisateurProfil(UtilisateurProfil utilisateurProfil)
        {
            _context.UtilisateurProfils.Add(utilisateurProfil);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UtilisateurProfilExists(utilisateurProfil.IdUtilisateur))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUtilisateurProfil", new { id = utilisateurProfil.IdUtilisateur }, utilisateurProfil);
        }

        // DELETE: api/UtilisateurProfils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUtilisateurProfil(int id)
        {
            var utilisateurProfil = await _context.UtilisateurProfils.FindAsync(id);
            if (utilisateurProfil == null)
            {
                return NotFound();
            }

            _context.UtilisateurProfils.Remove(utilisateurProfil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UtilisateurProfilExists(int id)
        {
            return _context.UtilisateurProfils.Any(e => e.IdUtilisateur == id);
        }
    }
}
