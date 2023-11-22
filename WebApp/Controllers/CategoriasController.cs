using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext db;
        public CategoriasController(AppDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var listaCategorias = db.TblCategorias.ToList();
            return View(listaCategorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

    }
}
