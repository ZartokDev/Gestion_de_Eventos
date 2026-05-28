using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoInventariosController : ControllerBase
    {
        private ITipoInventariosNegocio? ITipoInventariosNegocio;

        public TipoInventariosController()
        {
            this.ITipoInventariosNegocio = new TipoInventariosNegocio();
        }

        [HttpGet]
        public List<TipoInventarios> Consultar()
        {
            if (this.ITipoInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoInventariosNegocio!.Consultar();
        }

        [HttpPost]
        public TipoInventarios Guardar(TipoInventarios entidad)
        {
            if (this.ITipoInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoInventariosNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public TipoInventarios Modificar(TipoInventarios entidad)
        {
            if (this.ITipoInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoInventariosNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public TipoInventarios Eliminar(TipoInventarios entidad)
        {
            if (this.ITipoInventariosNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoInventariosNegocio.Eliminar(entidad);
        }


    }
}
