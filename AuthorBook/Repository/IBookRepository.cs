using AuthorBook.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Repository
{
    public interface IBookRepository
    {
        Task<Book> createBook(Book book);
        Task<List<Book>> getBooks();
        Task<Book> getBook(int id);
        Task<Book> getBooksAuthor();
        Task<ActionResult> delete(int id);
        Task<Book> updateBook(int id, Book book);


    }

}

