using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    //Class de coneccion a la Base de Datos
    public class AppDbContext : DbContext
    {

        public DbSet<Departamento> TblDepartamentos { get; set; }
        public DbSet<Trabajador> TblTrabajadores { get; set; }
        public DbSet<ContactoEmergencia> TblContactosEmergencia { get; set; }
        public DbSet<CargaFamiliar> TblCargas { get; set; }
        public DbSet<Usuario> TblUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ApiWebListadoTrabajadores;Integrated Security=True;");
        }

    }

    public class ContactoEmergencia
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }

        [ForeignKey("Trabajador")]
        public string RutTrabajador { get; set; }
        public Trabajador Trabajador { get; set; }

    }

    public class CargaFamiliar
    {
        [Key]
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }

        [ForeignKey("Trabajador")]
        public string RutTrabajador { get; set; }
        public Trabajador Trabajador { get; set; }
    }


}
