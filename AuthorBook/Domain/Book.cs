using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorBook.Domain
{
    public class Book : Super
    {
        // PM> add-migration
        // PM> add-update
        //Entity = tabaler.
        //Required is called dataanotations or Property.
        [Required]
        [StringLength(32,ErrorMessage = "Title Length Can't be more than 32 Characters.")]
        public string title { get; set; }
        public int page { get; set; }
        public DateTime published { get; set; }
        [ForeignKey("Author.Id")]
        public int aurthorId { get; set; }
    }
}
