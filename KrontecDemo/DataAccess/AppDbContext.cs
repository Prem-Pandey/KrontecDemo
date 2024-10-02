using KrontecDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace KrontecDemo.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
