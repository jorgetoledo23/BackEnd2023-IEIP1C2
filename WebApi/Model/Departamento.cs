using System.ComponentModel.DataAnnotations;

namespace WebApi.Model
{
    public class Departamento
    {
        [Key]
        public int Cod_Dpto { get; set; }
        public string Nombre { get; set; }
    }

}
