using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize(Roles = "SuperAdministrador, Administrador")]
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
