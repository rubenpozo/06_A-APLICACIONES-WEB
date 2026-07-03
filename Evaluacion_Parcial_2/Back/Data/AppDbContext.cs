using EvaluacionParcial2.Models;
using Microsoft.EntityFrameworkCore;

namespace EvaluacionParcial2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<SesionEntrenamiento> Sesiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Datos iniciales para Miembros
            modelBuilder.Entity<Miembro>().HasData(
                new Miembro { MiembroId = 1, Nombre = "Carlos", Apellido = "Ramírez", FechaNacimiento = new DateTime(1990, 5, 12), TipoMembresia = "Premium" },
                new Miembro { MiembroId = 2, Nombre = "María", Apellido = "González", FechaNacimiento = new DateTime(1985, 8, 23), TipoMembresia = "Básica" },
                new Miembro { MiembroId = 3, Nombre = "José", Apellido = "Martínez", FechaNacimiento = new DateTime(1998, 2, 10), TipoMembresia = "Estándar" }
            );

            // Datos iniciales para Entrenadores
            modelBuilder.Entity<Entrenador>().HasData(
                new Entrenador { EntrenadorId = 1, Nombre = "Ana López", Especialidad = "Cardio", Telefono = "0991234567", Email = "ana.lopez@gym.com" },
                new Entrenador { EntrenadorId = 2, Nombre = "Pedro Herrera", Especialidad = "Pesas", Telefono = "0987654321", Email = "pedro.herrera@gym.com" },
                new Entrenador { EntrenadorId = 3, Nombre = "Lucía Torres", Especialidad = "Yoga", Telefono = "0971112233", Email = "lucia.torres@gym.com" }
            );

            // Datos iniciales para Sesiones de entrenamiento
            modelBuilder.Entity<SesionEntrenamiento>().HasData(
                new SesionEntrenamiento { SesionId = 1, MiembroId = 1, EntrenadorId = 2, FechaSesion = new DateTime(2026, 7, 5, 10, 0, 0), Duracion = 60, TipoSesion = "Pesas" },
                new SesionEntrenamiento { SesionId = 2, MiembroId = 2, EntrenadorId = 1, FechaSesion = new DateTime(2026, 7, 6, 9, 0, 0), Duracion = 45, TipoSesion = "Cardio" },
                new SesionEntrenamiento { SesionId = 3, MiembroId = 3, EntrenadorId = 3, FechaSesion = new DateTime(2026, 7, 7, 8, 30, 0), Duracion = 90, TipoSesion = "Yoga" }
            );
        }
    }
}
