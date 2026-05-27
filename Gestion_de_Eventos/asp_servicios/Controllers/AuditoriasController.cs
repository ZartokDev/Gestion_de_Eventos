using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControllerBase
    {
        private IAuditoriasNegocio? IAuditoriasNegocio;

        public AuditoriasController()
        {
            this.IAuditoriasNegocio = new AuditoriasNegocio();
        }

        [HttpGet]
        public List<Auditorias> Consultar()
        {
            if (this.IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return this.IAuditoriasNegocio!.Consultar();
        }

        [HttpPost]
        public Auditorias Guardar(Auditorias entidad)
        {
            if (this.IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return this.IAuditoriasNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Auditorias Modificar(Auditorias entidad)
        {
            if (this.IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return this.IAuditoriasNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Auditorias Eliminar(Auditorias entidad)
        {
            if (this.IAuditoriasNegocio == null)
                throw new Exception("No implementado");
            return this.IAuditoriasNegocio.Eliminar(entidad);
        }

    }
}
