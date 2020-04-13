using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public abstract class AbstractCosmosDbContext : DbContext
    {
        protected const string DefaultContainerName = "EFCoreCollection";

        protected AbstractCosmosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}