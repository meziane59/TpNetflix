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
    public class FilmFilmCategoriesController : ControllerBase
    {
        private readonly masterContext _context;

        public FilmFilmCategoriesController(masterContext context)
        {
            _context = context;
        }

        // GET: api/FilmFilmCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmFilmCategorie>>> GetFilmFilmCategories()
        {
            return await _context.FilmFilmCategories.ToListAsync();
        }

        // GET: api/FilmFilmCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmFilmCategorie>> GetFilmFilmCategorie(int id)
        {
            var filmFilmCategorie = await _context.FilmFilmCategories.FindAsync(id);

            if (filmFilmCategorie == null)
            {
                return NotFound();
            }

            return filmFilmCategorie;
        }

        // PUT: api/FilmFilmCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmFilmCategorie(int id, FilmFilmCategorie filmFilmCategorie)
        {
            if (id != filmFilmCategorie.IdFilm)
            {
                return BadRequest();
            }

            _context.Entry(filmFilmCategorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmFilmCategorieExists(id))
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

        // POST: api/FilmFilmCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmFilmCategorie>> PostFilmFilmCategorie(FilmFilmCategorie filmFilmCategorie)
        {
            _context.FilmFilmCategories.Add(filmFilmCategorie);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FilmFilmCategorieExists(filmFilmCategorie.IdFilm))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFilmFilmCategorie", new { id = filmFilmCategorie.IdFilm }, filmFilmCategorie);
        }

        // DELETE: api/FilmFilmCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmFilmCategorie(int id)
        {
            var filmFilmCategorie = await _context.FilmFilmCategories.FindAsync(id);
            if (filmFilmCategorie == null)
            {
                return NotFound();
            }

            _context.FilmFilmCategories.Remove(filmFilmCategorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmFilmCategorieExists(int id)
        {
            return _context.FilmFilmCategories.Any(e => e.IdFilm == id);
        }
    }
}
