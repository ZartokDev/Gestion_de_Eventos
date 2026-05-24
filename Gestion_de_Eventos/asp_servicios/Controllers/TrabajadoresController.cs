using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TrabajadoresController : ControllerBase
    {
        private ITrabajadoresNegocio? ITrabajadoresNegocio;

        public TrabajadoresController()
        {
            this.ITrabajadoresNegocio = new TrabajadoresNegocio();
        }

        [HttpGet]
        public List<Trabajadores> Consultar()
        {
            if (this.ITrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITrabajadoresNegocio!.Consultar();
        }

        [HttpPost]
        public Trabajadores Guardar(Trabajadores entidad)
        {
            if (this.ITrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITrabajadoresNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Trabajadores Modificar(Trabajadores entidad)
        {
            if (this.ITrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITrabajadoresNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Trabajadores Eliminar(Trabajadores entidad)
        {
            if (this.ITrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITrabajadoresNegocio.Eliminar(entidad);
        }
    }
}
