using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthorBook.Domain;
using AuthorBook.Env;

namespace AuthorBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AurthorsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AurthorsController(DatabaseContext context) // DInjection  
        {
            _context = context;
        }

        // GET: api/Aurthors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aurthor>>> Getauthors()
        {
            return await _context.authors.ToListAsync();
        }

        // GET: api/Aurthors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aurthor>> GetAurthor(int id)
        {
            var aurthor = await _context.authors.FindAsync(id);

            if (aurthor == null)
            {
                return NotFound();
            }

            return aurthor;
        }

        // PUT: api/Aurthors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAurthor(int id, Aurthor aurthor)
        {
            if (id != aurthor.id)
            {
                return BadRequest();
            }

            _context.Entry(aurthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AurthorExists(id))
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

        // POST: api/Aurthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aurthor>> PostAurthor(Aurthor aurthor)
        {
            _context.authors.Add(aurthor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAurthor", new { id = aurthor.id }, aurthor);
        }

        // DELETE: api/Aurthors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAurthor(int id)
        {
            var aurthor = await _context.authors.FindAsync(id);
            if (aurthor == null)
            {
                return NotFound();
            }

            _context.authors.Remove(aurthor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AurthorExists(int id)
        {
            return _context.authors.Any(e => e.id == id);
        }
    }
}
