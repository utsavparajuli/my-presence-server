using Microsoft.EntityFrameworkCore;

namespace MyPresence.Server.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> Applications { get; set; }
        // Other DbSet properties for additional entities if needed
    }
}
