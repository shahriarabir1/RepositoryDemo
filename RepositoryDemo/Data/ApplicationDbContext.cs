using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Model;

namespace RepositoryDemo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
