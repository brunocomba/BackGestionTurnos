using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Models.ConnectionDB;

namespace Models
{
    public class DesignTimeDbcontext : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Especifica la cadena de conexión a tu base de datos
            optionsBuilder.UseSqlServer("Server=tcp:srvgestionturnos.database.windows.net,1433;Initial Catalog=GestionTurnosWeb;Persist Security Info=False;User ID=brunodba;Password=Lacoca2024;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            // Devolver una instancia del contexto con las opciones configuradas
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
