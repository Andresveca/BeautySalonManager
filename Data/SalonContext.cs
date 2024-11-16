using BeautySalon.Models;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Data
{
    public class SalonContext : DbContext
    {
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=BeautySalonManagerDB; Trusted_Connection=True;");
        }

    }
}
