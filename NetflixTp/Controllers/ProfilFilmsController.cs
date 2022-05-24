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
    public class ProfilFilmsController : ControllerBase
    {
        private readonly masterContext _context;

        public ProfilFilmsController(masterContext context)
        {
            _context = context;
        }

        // GET: api/ProfilFilms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfilFilm>>> GetProfilFilms()
        {
            return await _context.ProfilFilms.ToListAsync();
        }

        // GET: api/ProfilFilms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfilFilm>> GetProfilFilm(int id)
        {
            var profilFilm = await _context.ProfilFilms.FindAsync(id);

            if (profilFilm == null)
            {
                return NotFound();
            }

            return profilFilm;
        }

        // PUT: api/ProfilFilms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfilFilm(int id, ProfilFilm profilFilm)
        {
            if (id != profilFilm.IdProfil)
            {
                return BadRequest();
            }

            _context.Entry(profilFilm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfilFilmExists(id))
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

        // POST: api/ProfilFilms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfilFilm>> PostProfilFilm(ProfilFilm profilFilm)
        {
            _context.ProfilFilms.Add(profilFilm);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProfilFilmExists(profilFilm.IdProfil))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProfilFilm", new { id = profilFilm.IdProfil }, profilFilm);
        }

        // DELETE: api/ProfilFilms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfilFilm(int id)
        {
            var profilFilm = await _context.ProfilFilms.FindAsync(id);
            if (profilFilm == null)
            {
                return NotFound();
            }

            _context.ProfilFilms.Remove(profilFilm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfilFilmExists(int id)
        {
            return _context.ProfilFilms.Any(e => e.IdProfil == id);
        }
    }
}
