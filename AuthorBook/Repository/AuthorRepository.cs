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
    // Define some methods that can respond to my controller
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DatabaseContext _context;
        // Readonly bestpractice to prevent accident changes.
        public AuthorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Aurthor> create(Aurthor author)
        {
            author.createdAt = DateTime.UtcNow;
            // This creates an Author;

            _context.authors.Add(author);
            await _context.SaveChangesAsync();
             return author;
            //throw new NotImplementedException();
        }

       // public async Task<List<Aurthor>> getAuthors()
        public async Task<List<Aurthor>> getAuthors()
        {
            var author =  await _context.authors.ToListAsync();
            return author;
        }
        public async Task<List<ActionResult>> getAuthorsBooks(int id)
        {
            Aurthor author = await _context.authors.Where(a => a.id == id).FirstOrDefaultAsync();

                var books = await _context.Book.Where(e => e.aurthorId == author.id).ToListAsync();

            return null;
        }


        public async Task<ActionResult> delete(int id)
        {
            Aurthor author = await _context.authors.FindAsync(id);
            if (author != null)
            {
                _context.authors.Remove(author);
                await _context.SaveChangesAsync();
            }
            return author == null ? new NotFoundResult(): new OkResult();
            

        }

        public async Task<Aurthor> getAuthor(int id)
        {
            Aurthor author = await _context.authors.FindAsync(id);
            return author;
        }

        public async Task<Aurthor> getAuthor2(int id)
        {
            string name = "manish";
            Aurthor author = await _context.authors.Where((a) => a.id == id).FirstOrDefaultAsync();
            List<Aurthor> obj = await _context.authors.Where(a => a.id < id).ToListAsync();
            Aurthor obj2 = await _context.authors.Where(b => b.firstname == name).SingleOrDefaultAsync();
            return author;

        }


        
        public async  Task<ActionResult> updateAuthor(int id, Aurthor author)
        {
            EntityState entity = _context.Entry(author).State = EntityState.Modified;
            author.updatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return null;


        }
    }
}
