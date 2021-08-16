using AuthorBook.Domain;
using AuthorBook.DTO;
using AuthorBook.Repository;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Aurthor> createAuthor(Aurthor author)
        {
            return await _authorRepository.create(author);            
        }

        public async Task<ActionResult> deleteAuthor(int id)
        {
            return await _authorRepository.delete(id);
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

        public async Task<List<AuthorDTO>> getAuthors()
        {
            List<Aurthor> authorsList = await _authorRepository.getAuthors();
            List<AuthorDTO> dto = authorsList.Select(x => new AuthorDTO() { firstname = x.firstname, lastname = x.lastname }).ToList();
            

            return dto;

        }

        public async Task<List<Book>> getAuthorsBooks(int authorId)
        {
            List<Book> authorsBook = await _authorRepository.getAuthorsBooks(authorId);
            return authorsBook;
        }

        public async Task<ActionResult> updateAuthor(int id, Aurthor author)
        {
            ActionResult updateAuthor = await _authorRepository.updateAuthor(id,author);
            return updateAuthor;
        }
    }
}
