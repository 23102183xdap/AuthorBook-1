using AuthorBook.Domain;
using AuthorBook.Env;
using AuthorBook.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Endpoint
    public class AurthorTestController : ControllerBase
    {
        public AurthorTestController(IAuthorRepository authorRep)
        {
            _authorRep = authorRep;
        }
        public IAuthorRepository _authorRep { get; set; }
        //Methods that calls the database.
        [HttpGet]
        // public async Task<ActionResult<IEnumerable<Aurthor>>> GetAuthors()
        public async Task<IActionResult> getAuthors()
        {
            try
            {
                var authors = await _authorRep.getAuthors();
                if (authors == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, authors);
                }
                else if (authors.Count == 0) { return NoContent(); }// test if the array is empty

                return Ok(authors);
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAurthor(int id)
        {
            await _authorRep.delete(id);

            return NoContent();

        }

        //[HttpPost]
        [HttpPost]
        public async Task<IActionResult> PostAurthor(Aurthor aurthor)
        {
            // IMpl Try catch in here.
            //Her inde skal vi kalde create.
            try
            {
                // Test if creat or not created.

                if (aurthor == null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                //  return await _authorRep.create(aurthor);
                // CreatedAtAction("GetAurthor", new { id = aurthor.id }, aurthor);
                Aurthor createdAuthor = await _authorRep.create(aurthor);
                return Created("", createdAuthor);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aurthor>> getAuthor(int id)
        {
            try
            {

                Aurthor author = await _authorRep.getAuthor(id);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(author);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateAuthor(int id, Aurthor author)
        {
            try
            {
                if (id != author.id)
                {
                    return BadRequest();
                }
                var updatedState = await _authorRep.updateAuthor(id, author);

                return Ok(updatedState);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }




    }
}
