using AuthorBook.Domain;
using AuthorBook.DTO;
using AuthorBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Services
{
    public class AuthorServices :IAuthorServices
    {
        //    public Task<ActionResult<class>> methodName()
        //    {
        //        //CAll autorepo and get data from CRUD
        //        // _context.authors.getAuthors();
        //        // translate from author to authorDTO
        //        // return to controller.
        //    }

        private readonly IAuthorRepository _authorRepository;

        public AuthorServices(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorDTO> getAuthorById(int id)
        {
            Aurthor authorDto = await _authorRepository.getAuthor(id);
            AuthorDTO dto = new AuthorDTO
            {
                firstname = authorDto.firstname,
                lastname = authorDto.lastname
            };
            return dto;
        }
    }
}
