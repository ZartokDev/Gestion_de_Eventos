using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HorariosController : ControllerBase
    {
        private IHorariosNegocio? IHorariosNegocio;

        public HorariosController()
        {
            this.IHorariosNegocio = new HorariosNegocio();
        }

        [HttpGet]
        public List<Horarios> Consultar()
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio!.Consultar();
        }

        [HttpPost]
        public Horarios Guardar(Horarios entidad)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Horarios Modificar(Horarios entidad)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Horarios Eliminar(Horarios entidad)
        {
            if (this.IHorariosNegocio == null)
                throw new Exception("No implementado");
            return this.IHorariosNegocio.Eliminar(entidad);
        }
    }
}
