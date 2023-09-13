using Microsoft.EntityFrameworkCore;
namespace WebApi.Model
{
    //Class de coneccion a la Base de Datos
    public class AppDbContext : DbContext
    {

        public DbSet<Departamento> TblDepartamentos { get; set; }
        public DbSet<Trabajador> TblTrabajadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ApiWebListadoTrabajadores;Integrated Security=True;");
        }

    }
}
