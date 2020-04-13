using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class CosmosDbContextTwo : AbstractCosmosDbContext
    {
        public CosmosDbContextTwo(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer(DefaultContainerName);
            modelBuilder.Entity<Author>().HasPartitionKey(nameof(Author.PartitionKey));
            modelBuilder.Entity<Author>().OwnsMany(x => x.Books);
            base.OnModelCreating(modelBuilder);
        }
    }
}