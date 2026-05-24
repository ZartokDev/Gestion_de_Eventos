using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GruposController : ControllerBase
    {
        private IGruposNegocio? IGruposNegocio;

        public GruposController()
        {
            this.IGruposNegocio = new GruposNegocio();
        }

        [HttpGet]
        public List<Grupos> Consultar()
        {
            if (this.IGruposNegocio == null)
                throw new Exception("No implementado");
            return this.IGruposNegocio!.Consultar();
        }

        [HttpPost]
        public Grupos Guardar(Grupos entidad)
        {
            if (this.IGruposNegocio == null)
                throw new Exception("No implementado");
            return this.IGruposNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Grupos Modificar(Grupos entidad)
        {
            if (this.IGruposNegocio == null)
                throw new Exception("No implementado");
            return this.IGruposNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Grupos Eliminar(Grupos entidad)
        {
            if (this.IGruposNegocio == null)
                throw new Exception("No implementado");
            return this.IGruposNegocio.Eliminar(entidad);
        }
    }
}
