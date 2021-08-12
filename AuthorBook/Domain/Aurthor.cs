using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Domain
{
    public class Aurthor : Super
    {
        // 
        public string firstname { get; set; }
        public string lastname { get; set; }
        public List<Book> books { get; set; }// Entity Framework used here.
        
    }
}
