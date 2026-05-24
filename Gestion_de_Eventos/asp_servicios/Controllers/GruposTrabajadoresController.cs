using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GruposTrabajadoresController : ControllerBase
    {
        private IGruposTrabajadoresNegocio? IGruposTrabajadoresNegocio;

        public GruposTrabajadoresController()
        {
            this.IGruposTrabajadoresNegocio = new GruposTrabajadoresNegocio();
        }

        [HttpGet]
        public List<GruposTrabajadores> Consultar()
        {
            if (this.IGruposTrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.IGruposTrabajadoresNegocio!.Consultar();
        }

        [HttpPost]
        public GruposTrabajadores Guardar(GruposTrabajadores entidad)
        {
            if (this.IGruposTrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.IGruposTrabajadoresNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public GruposTrabajadores Modificar(GruposTrabajadores entidad)
        {
            if (this.IGruposTrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.IGruposTrabajadoresNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public GruposTrabajadores Eliminar(GruposTrabajadores entidad)
        {
            if (this.IGruposTrabajadoresNegocio == null)
                throw new Exception("No implementado");
            return this.IGruposTrabajadoresNegocio.Eliminar(entidad);
        }
    }
}
