using AuthorBook.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Repository
{
    public interface IAuthorRepository
    {
        Task<Aurthor> create(Aurthor author);
        Task<Aurthor> getAuthor2(int id);
        Task<List<Aurthor>> getAuthors();
        Task<Aurthor> getAuthor(int id);
        Task<List<Book>> getAuthorsBooks(int authorId);
        Task<ActionResult> delete(int id);
        Task<ActionResult> updateAuthor(int id,Aurthor author);
    }
}
