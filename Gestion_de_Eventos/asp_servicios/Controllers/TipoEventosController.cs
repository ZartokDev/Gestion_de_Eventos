using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoEventosController : ControllerBase
    {
        private ITipoEventosNegocio? ITipoEventosNegocio;

        public TipoEventosController()
        {
            this.ITipoEventosNegocio = new TipoEventosNegocio();
        }

        [HttpGet]
        public List<TipoEventos> Consultar()
        {
            if (this.ITipoEventosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoEventosNegocio!.Consultar();
        }

        [HttpPost]
        public TipoEventos Guardar(TipoEventos entidad)
        {
            if (this.ITipoEventosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoEventosNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public TipoEventos Modificar(TipoEventos entidad)
        {
            if (this.ITipoEventosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoEventosNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public TipoEventos Eliminar(TipoEventos entidad)
        {
            if (this.ITipoEventosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoEventosNegocio.Eliminar(entidad);
        }


    }
}
