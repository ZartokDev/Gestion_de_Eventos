using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControllerBase
    {
        private IProveedoresNegocio? IProveedoresNegocio;

        public ProveedoresController()
        {
            this.IProveedoresNegocio = new ProveedoresNegocio();
        }

        [HttpGet]
        public List<Proveedores> Consultar()
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio!.Consultar();
        }

        [HttpPost]
        public Proveedores Guardar(Proveedores entidad)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Proveedores Modificar(Proveedores entidad)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Proveedores Eliminar(Proveedores entidad)
        {
            if (this.IProveedoresNegocio == null)
                throw new Exception("No implementado");
            return this.IProveedoresNegocio.Eliminar(entidad);
        }
    }
}
