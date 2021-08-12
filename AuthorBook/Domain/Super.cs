using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthorBook.Domain
{
    public class Super
    {
        public int id { get; set; } // PK for all the tables.
        [JsonIgnore] // 
        public DateTime deletedAt { get; set; }
        [JsonIgnore]

        public DateTime createdAt { get; set; }
        [JsonIgnore]

        public DateTime updatedAt { get; set; }

    }
}
