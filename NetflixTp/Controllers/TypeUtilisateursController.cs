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
    public class TypeUtilisateursController : ControllerBase
    {
        private readonly masterContext _context;

        public TypeUtilisateursController(masterContext context)
        {
            _context = context;
        }

        // GET: api/TypeUtilisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeUtilisateur>>> GetTypeUtilisateurs()
        {
            return await _context.TypeUtilisateurs.ToListAsync();
        }

        // GET: api/TypeUtilisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeUtilisateur>> GetTypeUtilisateur(int id)
        {
            var typeUtilisateur = await _context.TypeUtilisateurs.FindAsync(id);

            if (typeUtilisateur == null)
            {
                return NotFound();
            }

            return typeUtilisateur;
        }

        // PUT: api/TypeUtilisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeUtilisateur(int id, TypeUtilisateur typeUtilisateur)
        {
            if (id != typeUtilisateur.IdTypeUtilisateur)
            {
                return BadRequest();
            }

            _context.Entry(typeUtilisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeUtilisateurExists(id))
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

        // POST: api/TypeUtilisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeUtilisateur>> PostTypeUtilisateur(TypeUtilisateur typeUtilisateur)
        {
            _context.TypeUtilisateurs.Add(typeUtilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeUtilisateur", new { id = typeUtilisateur.IdTypeUtilisateur }, typeUtilisateur);
        }

        // DELETE: api/TypeUtilisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeUtilisateur(int id)
        {
            var typeUtilisateur = await _context.TypeUtilisateurs.FindAsync(id);
            if (typeUtilisateur == null)
            {
                return NotFound();
            }

            _context.TypeUtilisateurs.Remove(typeUtilisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeUtilisateurExists(int id)
        {
            return _context.TypeUtilisateurs.Any(e => e.IdTypeUtilisateur == id);
        }
    }
}
