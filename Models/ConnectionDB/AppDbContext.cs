using Microsoft.EntityFrameworkCore;
using Models.Clases;

namespace Models.ConnectionDB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cancha> Canchas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<ElementosCancha> ElementosCancha { get; set; }
        public DbSet<Deporte> Deportes { get; set; }


       
    }
}
