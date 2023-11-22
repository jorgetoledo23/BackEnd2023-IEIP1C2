using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    //Class de coneccion a la Base de Datos
    public class AppDbContext : DbContext
    {

        public DbSet<Usuario> TblUsuarios { get; set; }

        public DbSet<Producto> TblProductos { get; set; }
        public DbSet<Categoria> TblCategorias { get; set; }
        public DbSet<Imagen> TblImagenes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AppWebProductos2023;Integrated Security=True;");
        }

    }


}
