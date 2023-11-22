using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            var p = new Producto();
            var listaImagenes = new List<string>()
            {
                "https://falabella.scene7.com/is/image/Falabella/15872189_4?wid=1500&hei=1500&qlt=70",
                "https://falabella.scene7.com/is/image/Falabella/15872189_10?wid=1500&hei=1500&qlt=70",
                "https://falabella.scene7.com/is/image/Falabella/15872189_2?wid=1500&hei=1500&qlt=70",
                "https://falabella.scene7.com/is/image/Falabella/15872189_3?wid=1500&hei=1500&qlt=70",
                "https://falabella.scene7.com/is/image/Falabella/15872189_1?wid=1500&hei=1500&qlt=70"
            };
            //p.Imagenes = listaImagenes;


            return View(p);
        }
    }
}
