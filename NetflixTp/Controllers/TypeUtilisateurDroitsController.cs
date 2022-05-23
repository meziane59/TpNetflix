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
    public class TypeUtilisateurDroitsController : ControllerBase
    {
        private readonly masterContext _context;

        public TypeUtilisateurDroitsController(masterContext context)
        {
            _context = context;
        }

        // GET: api/TypeUtilisateurDroits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeUtilisateurDroit>>> GetTypeUtilisateurDroits()
        {
            return await _context.TypeUtilisateurDroits.ToListAsync();
        }

        // GET: api/TypeUtilisateurDroits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeUtilisateurDroit>> GetTypeUtilisateurDroit(int id)
        {
            var typeUtilisateurDroit = await _context.TypeUtilisateurDroits.FindAsync(id);

            if (typeUtilisateurDroit == null)
            {
                return NotFound();
            }

            return typeUtilisateurDroit;
        }

        // PUT: api/TypeUtilisateurDroits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeUtilisateurDroit(int id, TypeUtilisateurDroit typeUtilisateurDroit)
        {
            if (id != typeUtilisateurDroit.IdTypeUtilisateur)
            {
                return BadRequest();
            }

            _context.Entry(typeUtilisateurDroit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeUtilisateurDroitExists(id))
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

        // POST: api/TypeUtilisateurDroits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeUtilisateurDroit>> PostTypeUtilisateurDroit(TypeUtilisateurDroit typeUtilisateurDroit)
        {
            _context.TypeUtilisateurDroits.Add(typeUtilisateurDroit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TypeUtilisateurDroitExists(typeUtilisateurDroit.IdTypeUtilisateur))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTypeUtilisateurDroit", new { id = typeUtilisateurDroit.IdTypeUtilisateur }, typeUtilisateurDroit);
        }

        // DELETE: api/TypeUtilisateurDroits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeUtilisateurDroit(int id)
        {
            var typeUtilisateurDroit = await _context.TypeUtilisateurDroits.FindAsync(id);
            if (typeUtilisateurDroit == null)
            {
                return NotFound();
            }

            _context.TypeUtilisateurDroits.Remove(typeUtilisateurDroit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeUtilisateurDroitExists(int id)
        {
            return _context.TypeUtilisateurDroits.Any(e => e.IdTypeUtilisateur == id);
        }
    }
}
