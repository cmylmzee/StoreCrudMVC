using Microsoft.EntityFrameworkCore;
using StoreCrudMVC.Models;

namespace StoreCrudMVC.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }


        public DbSet<Product> Products { get; set; }
    }

    
}
