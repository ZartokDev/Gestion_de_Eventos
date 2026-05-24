using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoPatrocinadoresController : ControllerBase
    {
        private ITipoPatrocinadoresNegocio? ITipoPatrocinadoresNegocio;

        public TipoPatrocinadoresController()
        {
            this.ITipoPatrocinadoresNegocio = new TipoPatrocinadoresNegocio();
        }

        [HttpGet]
        public List<TipoPatrocinadores> Consultar()
        {
            if (this.ITipoPatrocinadoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoPatrocinadoresNegocio!.Consultar();
        }

    }
}
