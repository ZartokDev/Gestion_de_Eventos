using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OfertasController : ControllerBase
    {
        private IOfertasNegocio? IOfertasNegocio;

        public OfertasController()
        {
            this.IOfertasNegocio = new OfertasNegocio();
        }

        [HttpGet]
        public List<Ofertas> Consultar()
        {
            if (this.IOfertasNegocio == null)
                throw new Exception("No implementado");
            return this.IOfertasNegocio!.Consultar();
        }

        [HttpPost]
        public Ofertas Guardar(Ofertas entidad)
        {
            if (this.IOfertasNegocio == null)
                throw new Exception("No implementado");
            return this.IOfertasNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Ofertas Modificar(Ofertas entidad)
        {
            if (this.IOfertasNegocio == null)
                throw new Exception("No implementado");
            return this.IOfertasNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Ofertas Eliminar(Ofertas entidad)
        {
            if (this.IOfertasNegocio == null)
                throw new Exception("No implementado");
            return this.IOfertasNegocio.Eliminar(entidad);
        }
    }
}
