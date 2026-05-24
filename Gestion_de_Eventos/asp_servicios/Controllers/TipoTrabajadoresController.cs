using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoTrabajadoresController : ControllerBase
    {
        private ITipoTrabajadoresNegocio? ITipoTrabajadoresNegocio;

        public TipoTrabajadoresController()
        {
            this.ITipoTrabajadoresNegocio = new TipoTrabajadoresNegocio();
        }

        [HttpGet]
        public List<TipoTrabajadores> Consultar()
        {
            if (this.ITipoTrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoTrabajadoresNegocio!.Consultar();
        }
    }
}
