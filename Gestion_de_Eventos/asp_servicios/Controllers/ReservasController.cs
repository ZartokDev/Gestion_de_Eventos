using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReservasController : ControllerBase
    {
        private IReservasNegocio? IReservasNegocio;

        public ReservasController()
        {
            this.IReservasNegocio = new ReservasNegocio();
        }

        [HttpGet]
        public List<Reservas> Consultar()
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio!.Consultar();
        }

        [HttpPost]
        public Reservas Guardar(Reservas entidad)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public Reservas Modificar(Reservas entidad)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public Reservas Eliminar(Reservas entidad)
        {
            if (this.IReservasNegocio == null)
                throw new Exception("No implementado");
            return this.IReservasNegocio.Eliminar(entidad);
        }
    }
}
