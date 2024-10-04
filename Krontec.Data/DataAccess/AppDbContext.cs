using Krontec.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Krontec.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
