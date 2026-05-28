using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoTransportesController : ControllerBase
    {
        private ITipoTransportesNegocio? ITipoTransportesNegocio;

        public TipoTransportesController()
        {
            this.ITipoTransportesNegocio = new TipoTransportesNegocio();
        }

        [HttpGet]
        public List<TipoTransportes> Consultar()
        {
            if (this.ITipoTransportesNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoTransportesNegocio!.Consultar();
        }

        [HttpPost]
        public TipoTransportes Guardar(TipoTransportes entidad)
        {
            if (this.ITipoTransportesNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoTransportesNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public TipoTransportes Modificar(TipoTransportes entidad)
        {
            if (this.ITipoTransportesNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoTransportesNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public TipoTransportes Eliminar(TipoTransportes entidad)
        {
            if (this.ITipoTransportesNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoTransportesNegocio.Eliminar(entidad);
        }


    }
}
