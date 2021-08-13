using AuthorBook.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Services
{
    public interface IAuthorServices
    {
        //Methods goes here.
        Task<AuthorDTO> getAuthorById(int id);
    }
}
