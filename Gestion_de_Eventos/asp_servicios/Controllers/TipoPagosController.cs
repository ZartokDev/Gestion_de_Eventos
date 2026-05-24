using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoPagosController : ControllerBase
    {
        private ITipoPagosNegocio? ITipoPagosNegocio;

        public TipoPagosController()
        {
            this.ITipoPagosNegocio = new TipoPagosNegocio();
        }

        [HttpGet]
        public List<TipoPagos> Consultar()
        {
            if (this.ITipoPagosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoPagosNegocio!.Consultar();
        }

    }
}
