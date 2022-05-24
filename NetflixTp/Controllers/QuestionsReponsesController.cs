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
    public class QuestionsReponsesController : ControllerBase
    {
        private readonly masterContext _context;

        public QuestionsReponsesController(masterContext context)
        {
            _context = context;
        }

        // GET: api/QuestionsReponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionsReponse>>> GetQuestionsReponses()
        {
            return await _context.QuestionsReponses.ToListAsync();
        }

        // GET: api/QuestionsReponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionsReponse>> GetQuestionsReponse(int id)
        {
            var questionsReponse = await _context.QuestionsReponses.FindAsync(id);

            if (questionsReponse == null)
            {
                return NotFound();
            }

            return questionsReponse;
        }

        // PUT: api/QuestionsReponses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionsReponse(int id, QuestionsReponse questionsReponse)
        {
            if (id != questionsReponse.IdQuestionReponse)
            {
                return BadRequest();
            }

            _context.Entry(questionsReponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionsReponseExists(id))
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

        // POST: api/QuestionsReponses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionsReponse>> PostQuestionsReponse(QuestionsReponse questionsReponse)
        {
            _context.QuestionsReponses.Add(questionsReponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionsReponse", new { id = questionsReponse.IdQuestionReponse }, questionsReponse);
        }

        // DELETE: api/QuestionsReponses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionsReponse(int id)
        {
            var questionsReponse = await _context.QuestionsReponses.FindAsync(id);
            if (questionsReponse == null)
            {
                return NotFound();
            }

            _context.QuestionsReponses.Remove(questionsReponse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionsReponseExists(int id)
        {
            return _context.QuestionsReponses.Any(e => e.IdQuestionReponse == id);
        }
    }
}
