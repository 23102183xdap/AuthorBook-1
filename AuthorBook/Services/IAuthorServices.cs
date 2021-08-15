using AuthorBook.Domain;
using AuthorBook.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Services
{
    public interface IAuthorServices
    {
        //Methods goes here.
        Task<Aurthor> createAuthor(Aurthor author);
        Task<AuthorDTO> getAuthorById(int id);
        Task<List<AuthorDTO>> getAuthors(AuthorDTO authorDto);
        Task<ActionResult> deleteAuthor(int id);
        Task<ActionResult> updateAuthor(int id, Aurthor author);
        Task<ActionResult> getAuthorsBooks(int authorId);
    }
}
