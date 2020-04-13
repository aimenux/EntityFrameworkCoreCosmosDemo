using System;

namespace DataAccess.Entities
{
    public class Book
    {
        public Guid Id { get; set; }

        public Author Author { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public string PartitionKey { get; set; }

        public Book(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            PartitionKey = title;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}='{Id}' {nameof(Title)}='{Title}'";
        }
    }
}