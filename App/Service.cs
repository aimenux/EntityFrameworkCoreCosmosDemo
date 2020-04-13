using System;
using System.Threading.Tasks;
using DataAccess.Repositories;

namespace App
{
    public class Service
    {
        private readonly ICosmosRepository _cosmosRepository;

        public Service(ICosmosRepository cosmosRepository)
        {
            _cosmosRepository = cosmosRepository;
            _cosmosRepository.AddAuthorsAsync().GetAwaiter().GetResult();
        }

        public async Task PrintAuthorsAsync()
        {
            var authors = await _cosmosRepository.GetAuthorsAsync();
            Console.WriteLine($"Found {authors.Count} author(s)");
            foreach (var author in authors)
            {
                Console.WriteLine($"Author {author}");
            }
        }
    }
}
