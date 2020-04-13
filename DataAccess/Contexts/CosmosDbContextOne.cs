using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class CosmosDbContextOne : AbstractCosmosDbContext
    {
        public CosmosDbContextOne(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer(DefaultContainerName);
            modelBuilder.Entity<Book>().HasPartitionKey(nameof(Book.PartitionKey));
            modelBuilder.Entity<Author>().HasPartitionKey(nameof(Author.PartitionKey));
            base.OnModelCreating(modelBuilder);
        }
    }
}
