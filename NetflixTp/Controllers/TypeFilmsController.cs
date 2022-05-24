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
    public class TypeFilmsController : ControllerBase
    {
        private readonly masterContext _context;

        public TypeFilmsController(masterContext context)
        {
            _context = context;
        }

        // GET: api/TypeFilms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeFilm>>> GetTypeFilms()
        {
            return await _context.TypeFilms.ToListAsync();
        }

        // GET: api/TypeFilms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeFilm>> GetTypeFilm(int id)
        {
            var typeFilm = await _context.TypeFilms.FindAsync(id);

            if (typeFilm == null)
            {
                return NotFound();
            }

            return typeFilm;
        }

        // PUT: api/TypeFilms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeFilm(int id, TypeFilm typeFilm)
        {
            if (id != typeFilm.IdTypeFilm)
            {
                return BadRequest();
            }

            _context.Entry(typeFilm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeFilmExists(id))
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

        // POST: api/TypeFilms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeFilm>> PostTypeFilm(TypeFilm typeFilm)
        {
            _context.TypeFilms.Add(typeFilm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeFilm", new { id = typeFilm.IdTypeFilm }, typeFilm);
        }

        // DELETE: api/TypeFilms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeFilm(int id)
        {
            var typeFilm = await _context.TypeFilms.FindAsync(id);
            if (typeFilm == null)
            {
                return NotFound();
            }

            _context.TypeFilms.Remove(typeFilm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeFilmExists(int id)
        {
            return _context.TypeFilms.Any(e => e.IdTypeFilm == id);
        }
    }
}
