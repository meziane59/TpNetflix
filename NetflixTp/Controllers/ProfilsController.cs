﻿using System;
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
    public class ProfilsController : ControllerBase
    {
        private readonly masterContext _context;

        public ProfilsController(masterContext context)
        {
            _context = context;
        }

        // GET: api/Profils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profil>>> GetProfils()
        {
            return await _context.Profils.ToListAsync();
        }

        // GET: api/Profils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profil>> GetProfil(int id)
        {
            var profil = await _context.Profils.FindAsync(id);

            if (profil == null)
            {
                return NotFound();
            }

            return profil;
        }

        // PUT: api/Profils/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfil(int id, Profil profil)
        {
            if (id != profil.IdProfil)
            {
                return BadRequest();
            }

            _context.Entry(profil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfilExists(id))
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

        // POST: api/Profils
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profil>> PostProfil(Profil profil)
        {
            _context.Profils.Add(profil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfil", new { id = profil.IdProfil }, profil);
        }

        // DELETE: api/Profils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfil(int id)
        {
            var profil = await _context.Profils.FindAsync(id);
            if (profil == null)
            {
                return NotFound();
            }

            _context.Profils.Remove(profil);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfilExists(int id)
        {
            return _context.Profils.Any(e => e.IdProfil == id);
        }
    }
}
