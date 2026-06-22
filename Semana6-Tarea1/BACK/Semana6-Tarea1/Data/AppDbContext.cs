using Microsoft.EntityFrameworkCore;
using Semana6_Tarea1.Models;

namespace Semana6_Tarea1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
