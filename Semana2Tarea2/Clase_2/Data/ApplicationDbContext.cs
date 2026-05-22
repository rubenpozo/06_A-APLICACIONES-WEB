using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clase_2.Models;

namespace Clase_2.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<CentroRevision> CentrosRevision { get; set; }
    }
}
