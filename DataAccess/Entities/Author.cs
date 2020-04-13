using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PartitionKey { get; set; }

        public ICollection<Book> Books { get; set; }

        public Author(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            PartitionKey = name;
            Books = new List<Book>();
        }

        public override string ToString()
        {
            var books = string.Join(",", Books.Select(x => x.Title));
            return $"{nameof(Id)}='{Id}' {nameof(Name)}='{Name}' {nameof(Books)}='{books}'";
        }
    }
}
