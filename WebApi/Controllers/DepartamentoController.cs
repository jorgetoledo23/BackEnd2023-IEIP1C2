using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPut]
        [Route("uptdpto")]
        public IActionResult uptdpto(Departamento dpto)
        {
            //Select * From tblDepartamentos Where cod_dpto == cod
            var depa = contextInterno.TblDepartamentos
                .Where(x => x.Cod_Dpto == dpto.Cod_Dpto).FirstOrDefault();
            if(depa == null)
            {
                return BadRequest();
            }
            else
            {
                depa.Nombre = dpto.Nombre;
                contextInterno.Update(depa);
                contextInterno.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete]
        [Route("deldpto")]
        public IActionResult deldpto(int id)
        {
            var depa = contextInterno.TblDepartamentos
                .Where(x => x.Cod_Dpto == id).FirstOrDefault();
            if (depa == null) return BadRequest();
            contextInterno.Remove(depa);
            contextInterno.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("getByCod")]
        public async Task<IActionResult> getByCod(int id)
        {
            //Query para buscar Dpto segun su Cod
            var dpto = await contextInterno.TblDepartamentos
                .Where(x => x.Cod_Dpto == id)
                .FirstOrDefaultAsync();
            if (dpto == null) return NotFound();
            return Ok(dpto);        
        }

        [HttpGet]
        [Route("getByName")]
        public async Task<IActionResult> getByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return NotFound();
            var dpto = contextInterno.TblDepartamentos
                .FirstOrDefault(x => x.Nombre == name);
            if(dpto == null) return NotFound();
            return Ok(dpto);
        }

        [HttpGet]
        [Route("getByStartWith")]
        public async Task<IActionResult> getByStartWith(string key)
        {
            if (string.IsNullOrEmpty(key)) return NotFound();
            var dptos = await contextInterno.TblDepartamentos
                .Where(x => x.Nombre.StartsWith(key))
                .ToListAsync();
            if (dptos == null) return NotFound();
            return Ok(dptos);
        }



    }
}
