using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class EventosNegocio : IEventosNegocio
    {
        private IConexion? iConexion;

        public List<Eventos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Evento",
                Descripcion = $"Se consulto un Evento",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.Eventos!.ToList();

        }

        public Eventos Guardar(Eventos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Eventos!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Evento",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego un nuevo Evento con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Eventos Modificar(Eventos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Eventos.Attach(entidad);
            var entry = this.iConexion!.Entry<Eventos>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Evento",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico un Evento con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public Eventos Eliminar(Eventos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var evento = this.iConexion.Eventos!.FirstOrDefault(e => e.Id == entidad.Id);

            if (evento == null)
                throw new Exception("El evento no existe");

            evento.Estado = false;
            this.iConexion.Eventos!.Update(evento);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Evento",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino un Evento con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}