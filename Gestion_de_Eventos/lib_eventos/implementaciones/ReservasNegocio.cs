using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class ReservasNegocio : IReservasNegocio
    {
        private IConexion? iConexion;

        public List<Reservas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Reserva",
                Descripcion = $"Se consulto un Reserva",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.Reservas!.ToList();

        }

        public Reservas Guardar(Reservas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Reservas!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Reserva",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego un nuevo Reserva con id: {entidad.Id} con ubicacion {entidad.Ubicacion}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Reservas Modificar(Reservas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Reservas.Attach(entidad);
            var entry = this.iConexion!.Entry<Reservas>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Reserva",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico un Reserva con id: {entidad.Id} con ubicacion {entidad.Ubicacion}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public Reservas Eliminar(Reservas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Reservas!.Remove(entidad);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Reserva",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino un Reserva con id: {entidad.Id} con ubicacion {entidad.Ubicacion}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}
