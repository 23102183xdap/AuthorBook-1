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
    public class BookTestController : ControllerBase
    {
       public BookTestController(IBookRepository context)
        {
            _context = context;
        }
        public IBookRepository _context { get; set; }

        [HttpGet]
        public async Task<IActionResult> getBooks()
        {
            try
            {
                var books = await _context.getBooks();
                if (books == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, books);
                }
                else if (books.Count == 0) { return NoContent(); }// test if the array is empty

                return Ok(books);
            }
            catch (Exception e)
            {

                return Problem(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBook(int id)
        {
            await _context.delete(id);

            return NoContent();

        }

        //[HttpPost]
        [HttpPost]
        public async Task<IActionResult> postBook(Book book)
        {
            // IMpl Try catch in here.
            //Her inde skal vi kalde create.
            try
            {
                // Test if creat or not created.

                if (book == null || !ModelState.IsValid)
                {
                    return BadRequest(ModelState);

                }
                //  return await _authorRep.create(aurthor);
                // CreatedAtAction("GetAurthor", new { id = aurthor.id }, aurthor);
                Book createdBook = await _context.createBook(book);
                return Created("", createdBook);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> getBook(int id)
        {
            try
            {

                Book book = await _context.getBook(id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }
        [HttpGet("{id}/Aurthor")]
        public async Task<ActionResult<Aurthor>> getBooksAuthor(int id)
        {
            try
            {
                Book book = await _context.getBook(id);
                if(book == null)
                {
                    return NotFound();
                }
                var author = await _context.getBooksAuthor(book.id);
                return Ok(author);
            }
            catch (Exception e)
            {

                return Problem(e.Message);

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateBook(int id, Book book)
        {
            try
            {
                if (id != book.id)
                {
                    return BadRequest();
                }
                var updatedState = await _context.updateBook(id, book);

                return Ok(updatedState);

            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }



    }
}
