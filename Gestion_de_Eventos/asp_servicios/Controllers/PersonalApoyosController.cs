using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonalApoyosController : ControllerBase
    {
        private IPersonalApoyosNegocio? IPersonalApoyosNegocio;

        public PersonalApoyosController()
        {
            this.IPersonalApoyosNegocio = new PersonalApoyosNegocio();
        }

        [HttpGet]
        public List<PersonalApoyos> Consultar()
        {
            if (this.IPersonalApoyosNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonalApoyosNegocio!.Consultar();
        }

        [HttpPost]
        public PersonalApoyos Guardar(PersonalApoyos entidad)
        {
            if (this.IPersonalApoyosNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonalApoyosNegocio.Guardar(entidad);
        }
        [HttpPatch]
        public PersonalApoyos Modificar(PersonalApoyos entidad)
        {
            if (this.IPersonalApoyosNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonalApoyosNegocio.Modificar(entidad);
        }
        [HttpDelete]

        public PersonalApoyos Eliminar(PersonalApoyos entidad)
        {
            if (this.IPersonalApoyosNegocio == null)
                throw new Exception("No implementado");
            return this.IPersonalApoyosNegocio.Eliminar(entidad);
        }
    }
}
