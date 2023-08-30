namespace WebApplication1.Models
{
    public class Departamento
    {
        public string? NombreDepartamento { get; set; }
        public string? Descripcion { get; set; }

        public Departamento(string n, string d) { 
            
            NombreDepartamento = d;
            Descripcion = n;
            
        }

        public string getInformacionDepto()
        {
            int numero = 1;
            string nombre = "hola";

            if (numero > 1)
            {
                return "asdasd";
            }

            return false;

        }

    }
}
