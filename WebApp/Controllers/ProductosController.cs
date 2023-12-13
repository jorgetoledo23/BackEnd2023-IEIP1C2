using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize(Roles = "SuperAdministrador, Administrador")]
    public class ProductosController : Controller
    {
        private readonly AppDbContext db;
        public ProductosController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var prods = db.TblProductos
                .Include(p => p.Imagenes)
                .ToList();
            return View(prods);
        }

        public IActionResult Create()
        {
            var cats = db.TblCategorias.ToList();
            ViewData["Categorias"] = new SelectList(cats, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto P, [FromForm] string urlimagen )
        {
            if (ModelState.IsValid)
            {
                using (var transaccion = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Add(P);
                        db.SaveChanges();
                        var img = new Imagen()
                        {
                            ImgUrl = urlimagen,
                            IdProducto = P.Id
                        };
                        db.Add(img);
                        db.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                    }
                    
                }
                
                return RedirectToAction(nameof(Index));
            }

            return View(P);
        }


    }
}
