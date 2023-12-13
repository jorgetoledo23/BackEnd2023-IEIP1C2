using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public bool isBlocked { get; set; }
        public string ProfileImg { get; set; }
        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }


    public class Categoria
    {
        public int Id{ get; set; }
        public string Nombre{ get; set; }
        public string UrlImagen{ get; set; }

    }
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
    
        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        public Categoria? Categoria { get; set; }
        public List<Imagen> Imagenes { get; set; }

    }

    public class Imagen
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

        
    }




}
