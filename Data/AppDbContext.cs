using Microsoft.EntityFrameworkCore;
using CustomerImageApp.Models;

namespace CustomerImageApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerImage> CustomerImages { get; set; }
    }
}
