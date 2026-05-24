using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransportesController : ControllerBase
    {
        private ITransportesNegocio? ITransportesNegocio;

        public TransportesController()
        {
            this.ITransportesNegocio = new TransportesNegocio();
        }

        [HttpGet]
        public List<Transportes> Consultar()
        {
            if (this.ITransportesNegocio == null)
                throw new Exception("No implementado");
            return this.ITransportesNegocio!.Consultar();
        }

        [HttpPost]
        public Transportes Guardar(Transportes entidad)
        {
            if (this.ITransportesNegocio == null)
                throw new Exception("No implementado");
            return this.ITransportesNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Transportes Modificar(Transportes entidad)
        {
            if (this.ITransportesNegocio == null)
                throw new Exception("No implementado");
            return this.ITransportesNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Transportes Eliminar(Transportes entidad)
        {
            if (this.ITransportesNegocio == null)
                throw new Exception("No implementado");
            return this.ITransportesNegocio.Eliminar(entidad);
        }
    }
}
