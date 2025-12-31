using Microsoft.EntityFrameworkCore;
using InventoryManagement.API.Models;

namespace InventoryManagement.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }

    }
}
