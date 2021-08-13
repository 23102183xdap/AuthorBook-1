using Microsoft.AspNetCore.Http;
using AuthorBook.DTO;
using AuthorBook.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                if(author == null)
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
    }
}
