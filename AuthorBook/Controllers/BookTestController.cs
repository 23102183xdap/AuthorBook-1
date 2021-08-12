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
    }
}
