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
    public class FilmCategoriesController : ControllerBase
    {
        private readonly masterContext _context;

        public FilmCategoriesController(masterContext context)
        {
            _context = context;
        }

        // GET: api/FilmCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmCategorie>>> GetFilmCategories()
        {
            return await _context.FilmCategories.ToListAsync();
        }

        // GET: api/FilmCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmCategorie>> GetFilmCategorie(int id)
        {
            var filmCategorie = await _context.FilmCategories.FindAsync(id);

            if (filmCategorie == null)
            {
                return NotFound();
            }

            return filmCategorie;
        }

        // PUT: api/FilmCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmCategorie(int id, FilmCategorie filmCategorie)
        {
            if (id != filmCategorie.IdFilmCategorie)
            {
                return BadRequest();
            }

            _context.Entry(filmCategorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmCategorieExists(id))
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

        // POST: api/FilmCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmCategorie>> PostFilmCategorie(FilmCategorie filmCategorie)
        {
            _context.FilmCategories.Add(filmCategorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmCategorie", new { id = filmCategorie.IdFilmCategorie }, filmCategorie);
        }

        // DELETE: api/FilmCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmCategorie(int id)
        {
            var filmCategorie = await _context.FilmCategories.FindAsync(id);
            if (filmCategorie == null)
            {
                return NotFound();
            }

            _context.FilmCategories.Remove(filmCategorie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmCategorieExists(int id)
        {
            return _context.FilmCategories.Any(e => e.IdFilmCategorie == id);
        }
    }
}
