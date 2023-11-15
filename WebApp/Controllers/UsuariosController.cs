using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            List<string> list = new List<string>()
            {
                "Juanito",
                "Pedrito",
                "Robertito"
            };

            List<int> list2 = new List<int>()
            {
                1,
                20,
                54
            };

            var Model = new AdministracionUsuariosViewModel()
            {
                ListUsuarios = list,
                Roles = list2
            };

            return View(Model);
        }
    }
}
