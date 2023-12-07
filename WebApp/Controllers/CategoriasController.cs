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

        public IActionResult EditarCategoria(string IdCategoria)
        {
            var cat = db.TblCategorias.Find(Convert.ToInt32(IdCategoria));
            if(cat == null) return NotFound();

            return View(cat);
        }

        [HttpPost]
        public IActionResult EditarCategoria(Categoria C)
        {
            if (ModelState.IsValid)
            {
                db.Update(C);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(C);
            
        }

        public IActionResult EliminarCategoria(int IdCategoria)
        {
            var cat = db.TblCategorias.Find(IdCategoria);
            if (cat == null) return NotFound();
            db.Remove(cat);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }





    }
}
