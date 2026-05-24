using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LugaresController : ControllerBase
    {
        private ILugaresNegocio? ILugaresNegocio;

        public LugaresController()
        {
            this.ILugaresNegocio = new LugaresNegocio();
        }

        [HttpGet]
        public List<Lugares> Consultar()
        {
            if (this.ILugaresNegocio == null)
                throw new Exception("No implementado");
            return this.ILugaresNegocio!.Consultar();
        }

        [HttpPost]
        public Lugares Guardar(Lugares entidad)
        {
            if (this.ILugaresNegocio == null)
                throw new Exception("No implementado");
            return this.ILugaresNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Lugares Modificar(Lugares entidad)
        {
            if (this.ILugaresNegocio == null)
                throw new Exception("No implementado");
            return this.ILugaresNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Lugares Eliminar(Lugares entidad)
        {
            if (this.ILugaresNegocio == null)
                throw new Exception("No implementado");
            return this.ILugaresNegocio.Eliminar(entidad);
        }
    }
}
