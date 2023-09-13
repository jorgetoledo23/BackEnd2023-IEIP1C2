using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        //Agregar Dptos
        //Editar Dptos
        //Eliminar Dpto
        //Listar Todos Los Dptos
        //Buscar por Id
        //Buscar por Nombre
        //Filtro por Palabra Clave

        private readonly AppDbContext contextInterno;
        public DepartamentoController(AppDbContext contextExterno)
        {
            contextInterno = contextExterno;
        }


        [HttpPost]
        [Route("adddpto")]
        public IActionResult adddpto(Departamento Dpto)
        {
            //Insert INTO TblDpartamentos Values()
            contextInterno.Add(Dpto);
            contextInterno.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("getdptos")]
        public IActionResult getDptos()
        {
            //Select * From TblDepartamentos
            return Ok(contextInterno.TblDepartamentos.ToList());
        }

    }
}
