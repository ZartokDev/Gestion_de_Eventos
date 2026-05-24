using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class InventariosController : ControllerBase
    {
        private IInventariosNegocio? IInventariosNegocio;

        public InventariosController()
        {
            this.IInventariosNegocio = new InventariosNegocio();
        }

        [HttpGet]
        public List<Inventarios> Consultar()
        {
            if (this.IInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.IInventariosNegocio!.Consultar();
        }

        [HttpPost]
        public Inventarios Guardar(Inventarios entidad)
        {
            if (this.IInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.IInventariosNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Inventarios Modificar(Inventarios entidad)
        {
            if (this.IInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.IInventariosNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Inventarios Eliminar(Inventarios entidad)
        {
            if (this.IInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.IInventariosNegocio.Eliminar(entidad);
        }
    }
}
