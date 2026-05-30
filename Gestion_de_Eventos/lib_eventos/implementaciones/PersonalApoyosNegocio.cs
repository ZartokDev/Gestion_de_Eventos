using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class PersonalApoyosNegocio : IPersonalApoyosNegocio
    {
        private IConexion? iConexion;

        public List<PersonalApoyos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Personal de Apoyo",
                Descripcion = $"Se consulto un Personal de Apoyo",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.PersonalApoyos!.ToList();

        }

        public PersonalApoyos Guardar(PersonalApoyos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.PersonalApoyos!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Personal de Apoyo",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego un nuevo Personal de Apoyo con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public PersonalApoyos Modificar(PersonalApoyos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.PersonalApoyos.Attach(entidad);
            var entry = this.iConexion!.Entry<PersonalApoyos>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Personal de Apoyo",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico un Personal de Apoyo con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public PersonalApoyos Eliminar(PersonalApoyos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var personal = this.iConexion.Eventos!.FirstOrDefault(e => e.Id == entidad.Id);

            if (personal == null)
                throw new Exception("El evento no existe");

            personal.Estado = false;
            this.iConexion.Eventos!.Update(personal);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Personal de Apoyo",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino un Personal de Apoyo con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}