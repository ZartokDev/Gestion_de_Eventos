using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class AdministradoresNegocio : IAdministradoresNegocio
    {
        private IConexion? iConexion;

        public List<Administradores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Administrador",
                Descripcion = $"Se consulto un Administrador",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.Administradores!.ToList();

        }

        public Administradores Guardar(Administradores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Administradores!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Administrador",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego un nuevo Administrador con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Administradores Modificar(Administradores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Administradores.Attach(entidad);
            var entry = this.iConexion!.Entry<Administradores>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Administrador",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico un Administrador con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public Administradores Eliminar(Administradores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Administradores!.Remove(entidad);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Administrador",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino un Administrador con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}