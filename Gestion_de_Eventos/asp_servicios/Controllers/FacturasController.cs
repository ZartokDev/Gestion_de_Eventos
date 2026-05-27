using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacturasController : ControllerBase
    {
        private IFacturasNegocio? IFacturasNegocio;

        public FacturasController()
        {
            this.IFacturasNegocio = new FacturasNegocio();
        }

        [HttpGet]
        public List<Facturas> Consultar()
        {
            if (this.IFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IFacturasNegocio!.Consultar();
        }

        [HttpPost]
        public Facturas Guardar(Facturas entidad)
        {
            if (this.IFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IFacturasNegocio.Guardar(entidad);
        }

        [HttpPatch]
        public Facturas Modificar(Facturas entidad)
        {
            if (this.IFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IFacturasNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Facturas Eliminar(Facturas entidad)
        {
            if (this.IFacturasNegocio == null)
                throw new Exception("No implementado");
            return this.IFacturasNegocio.Eliminar(entidad);
        }

    }
}
