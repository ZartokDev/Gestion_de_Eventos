using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EventosController : ControllerBase
    {
        private IEventosNegocio? IEventosNegocio;

        public EventosController()
        {
            this.IEventosNegocio = new EventosNegocio();
        }

        [HttpGet]
        public List<Eventos> Consultar()
        {
            if (this.IEventosNegocio == null)
                throw new Exception("No implementado");
            return this.IEventosNegocio!.Consultar();
        }

        [HttpPost]
        public Eventos Guardar(Eventos entidad)
        {
            if (this.IEventosNegocio == null)
                throw new Exception("No implementado");
            return this.IEventosNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Eventos Modificar(Eventos entidad)
        {
            if (this.IEventosNegocio == null)
                throw new Exception("No implementado");
            return this.IEventosNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Eventos Eliminar(Eventos entidad)
        {
            if (this.IEventosNegocio == null)
                throw new Exception("No implementado");
            return this.IEventosNegocio.Eliminar(entidad);
        }
    }
}
