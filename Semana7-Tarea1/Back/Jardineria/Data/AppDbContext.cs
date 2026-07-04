using Microsoft.EntityFrameworkCore;

namespace Jardineria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Jardineria.Models.Jardineria> Jardinerias { get; set; }
    }
}
