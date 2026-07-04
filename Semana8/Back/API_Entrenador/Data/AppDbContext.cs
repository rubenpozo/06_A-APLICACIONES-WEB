using API_Entrenador.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace API_Entrenador.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Miembro> Miembros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entrenador>()
                .HasMany(e => e.Miembros)
                .WithOne(m => m.Entrenador)
                .HasForeignKey(m => m.EntrenadorId);
        }
    }
}
