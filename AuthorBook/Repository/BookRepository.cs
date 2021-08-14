using AuthorBook.Domain;
using AuthorBook.Env;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _context;

        public BookRepository(DatabaseContext Context)
        {
            _context = Context;
        }

        public async Task<Book> createBook(Book book)
        {
            book.createdAt = DateTime.UtcNow;
            _context.book.Add(book);
            await _context.SaveChangesAsync();
            return book;
            
        }

        public async Task<ActionResult> delete(int id)
        {
            Book book = await _context.book.FindAsync(id);
            if (book != null)
            {
                _context.book.Remove(book);
                await _context.SaveChangesAsync();

            }
            return book == null ? new NotFoundResult() :new OkResult();

        }

        public async Task<Book> getBook(int id)
        {
            Book book = await _context.book.FindAsync(id);
            return book;
        }


        public async Task<List<Book>> getBooks()
        {
            return await _context.book.ToListAsync();
        }


        public async Task<Aurthor> getBooksAuthor(int bookId)
        {
            var book = await _context.book.FindAsync(bookId);
            var author = await _context.authors.Where(a => a.id == book.aurthorId).SingleOrDefaultAsync();
            return author;
        }

        public async Task<Book> updateBook(int id, Book book)
        {
            EntityState entity = _context.Entry(book).State = EntityState.Modified;
            book.updatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
