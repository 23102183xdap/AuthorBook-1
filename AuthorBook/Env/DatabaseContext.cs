using AuthorBook.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Env
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Aurthor> authors { get; set; }
        public DbSet<AuthorBook.Domain.Book> Book { get; set; }
       // DbSet<Book> books { get; set; }
    }
}
