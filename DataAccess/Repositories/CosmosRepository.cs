using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class CosmosRepository : ICosmosRepository
    {
        private readonly AbstractCosmosDbContext _cosmosDbContext;

        public CosmosRepository(AbstractCosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
            _cosmosDbContext.Database.EnsureDeleted();
            _cosmosDbContext.Database.EnsureCreated();
        }

        public async Task<ICollection<Author>> GetAuthorsAsync()
        {
            var authors = await _cosmosDbContext.Authors.ToListAsync();
            return authors;
        }

        public async Task AddAuthorsAsync()
        {
            var names = new List<string>
            {
                "Stark",
                "Tyrell",
                "Greyjoy",
                "Baratheon",
                "Lannister",
                "Targaryen"
            };

            var authors = names
                .Select(x => new Author(x))
                .ToList();

            foreach (var author in authors)
            {
                var title = $"HISTORY OF {author.Name.ToUpper()}";
                author.Books = new List<Book>
                {
                    new Book(title)
                    {
                        Publisher = "GOT"
                    }
                };
            }

            await _cosmosDbContext.AddRangeAsync(authors);
            await _cosmosDbContext.SaveChangesAsync();
        }
    }
}
