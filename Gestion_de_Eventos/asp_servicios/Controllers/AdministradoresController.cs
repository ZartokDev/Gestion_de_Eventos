using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdministradoresController : ControllerBase
    {
        private IAdministradoresNegocio? IAdministradoresNegocio;

        public AdministradoresController()
        {
            this.IAdministradoresNegocio = new AdministradoresNegocio();
        }

        [HttpGet]
        public List<Administradores> Consultar()
        {
            if (this.IAdministradoresNegocio == null)
                throw new Exception("No implementado");
            return this.IAdministradoresNegocio!.Consultar();
        }

        [HttpPost]
        public Administradores Guardar(Administradores entidad)
        {
            if (this.IAdministradoresNegocio == null)
                throw new Exception("No implementado");
            return this.IAdministradoresNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Administradores Modificar(Administradores entidad)
        {
            if (this.IAdministradoresNegocio == null)
                throw new Exception("No implementado");
            return this.IAdministradoresNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Administradores Eliminar(Administradores entidad)
        {
            if (this.IAdministradoresNegocio == null)
                throw new Exception("No implementado");
            return this.IAdministradoresNegocio.Eliminar(entidad);
        }
    }
}
