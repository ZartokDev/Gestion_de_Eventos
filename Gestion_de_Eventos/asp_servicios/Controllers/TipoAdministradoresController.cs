using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TipoAdministradoresController : ControllerBase
    {
        private ITipoAdministradoresNegocio? ITipoAdministradoresNegocio;

        public TipoAdministradoresController()
        {
            this.ITipoAdministradoresNegocio = new TipoAdministradoresNegocio();
        }

        [HttpGet]
        public List<TipoAdministradores> Consultar()
        {
            if (this.ITipoAdministradoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoAdministradoresNegocio!.Consultar();
        }

        [HttpPost]
        public TipoAdministradores Guardar(TipoAdministradores entidad)
        {
            if (this.ITipoAdministradoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoAdministradoresNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public TipoAdministradores Modificar(TipoAdministradores entidad)
        {
            if (this.ITipoAdministradoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoAdministradoresNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public TipoAdministradores Eliminar(TipoAdministradores entidad)
        {
            if (this.ITipoAdministradoresNegocio == null)
                throw new Exception("No implementado");
            return this.ITipoAdministradoresNegocio.Eliminar(entidad);
        }


    }
}
