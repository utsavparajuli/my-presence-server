using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace MyPresence.Server.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Application> applications { get; set; }

        // Other DbSet properties for additional entities if needed
    }
}
