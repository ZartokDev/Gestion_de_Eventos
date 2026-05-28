using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoLugaresController : ControllerBase
    {
        private ITipoLugaresNegocio? ITipoLugaresNegocio;

        public TipoLugaresController()
        {
            this.ITipoLugaresNegocio = new TipoLugaresNegocio();
        }

        [HttpGet]
        public List<TipoLugares> Consultar()
        {
            if (this.ITipoLugaresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoLugaresNegocio!.Consultar();
        }

        [HttpPost]
        public TipoLugares Guardar(TipoLugares entidad)
        {
            if (this.ITipoLugaresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoLugaresNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public TipoLugares Modificar(TipoLugares entidad)
        {
            if (this.ITipoLugaresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoLugaresNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public TipoLugares Eliminar(TipoLugares entidad)
        {
            if (this.ITipoLugaresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoLugaresNegocio.Eliminar(entidad);
        }


    }
}
