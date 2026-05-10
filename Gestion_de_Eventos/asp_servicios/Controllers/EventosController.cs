using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
    }
}
