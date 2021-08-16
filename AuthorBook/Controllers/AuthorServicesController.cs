using Microsoft.AspNetCore.Http;
using AuthorBook.DTO;
using AuthorBook.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBook.Domain;

namespace AuthorBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // db => repositories => service / can be diff things => controller
    public class AuthorServicesController : ControllerBase
    {
        private readonly IAuthorServices _context;
        public AuthorServicesController(IAuthorServices context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> getAuthorById2(int id)
        {
            try
            {
                var author = await _context.getAuthorById(id);
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
        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> getAuthorsDto()
        {
            try
            {
                var authors = await _context.getAuthors();
                if (authors == null)
                {
                    return Problem("Got no Data");
                }
                if (authors.Count == 0)
                {
                    return NoContent();
                }
                return Ok(authors);
            }
            catch (Exception e)
            {

                return Problem(e.Message);

            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteAuthorById(int id)
        {
            try
            {
                 await _context.deleteAuthor(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return Problem(e.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> createAuthorDto(Aurthor author)
        {
            try
            {
                Aurthor createdAuthor = await _context.createAuthor(author);
                return Created("", createdAuthor);
            }
            catch (Exception e)
            {

                return Problem(e.Message);

            }
        }
        
        [HttpGet("Book/{id}")]
        public async Task<ActionResult<List<Book>>> getAuthorsBookById(int id)
        {
            try
            {
                var books = await _context.getAuthorsBooks(id);
                return books;
            }
            catch (Exception e)
            {

                return Problem(e.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updateAuthorById(int id, Aurthor author)
        {
            try
            {
                if (id != author.id)
                {
                    return BadRequest();

                }
                var updatedState = await _context.updateAuthor(id, author);

                return Ok(updatedState);
            }
            catch (Exception e)
            {

                return Problem(e.Message);

            }
        }
    }
}
