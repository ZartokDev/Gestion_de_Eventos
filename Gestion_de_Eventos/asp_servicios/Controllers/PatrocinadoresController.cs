using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PatrocinadoresController : ControllerBase
    {
        private IPatrocinadoresNegocio? IPatrocinadoresNegocio;

        public PatrocinadoresController()
        {
            this.IPatrocinadoresNegocio = new PatrocinadoresNegocio();
        }

        [HttpGet]
        public List<Patrocinadores> Consultar()
        {
            if (this.IPatrocinadoresNegocio == null)
                throw new Exception("No implementado");
            return this.IPatrocinadoresNegocio!.Consultar();
        }

        [HttpPost]
        public Patrocinadores Guardar(Patrocinadores entidad)
        {
            if (this.IPatrocinadoresNegocio == null)
                throw new Exception("No implementado");
            return this.IPatrocinadoresNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Patrocinadores Modificar(Patrocinadores entidad)
        {
            if (this.IPatrocinadoresNegocio == null)
                throw new Exception("No implementado");
            return this.IPatrocinadoresNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Patrocinadores Eliminar(Patrocinadores entidad)
        {
            if (this.IPatrocinadoresNegocio == null)
                throw new Exception("No implementado");
            return this.IPatrocinadoresNegocio.Eliminar(entidad);
        }
    }
}
