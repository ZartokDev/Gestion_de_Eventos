using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class TipoTrabajadoresNegocio : ITipoTrabajadoresNegocio
    {
        private IConexion? iConexion;

        public List<TipoTrabajadores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Tipo de Trabajador",
                Descripcion = $"Se consulto un Tipo de Trabajador",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.TipoTrabajadores!.ToList();

        }

        public TipoTrabajadores Guardar(TipoTrabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.TipoTrabajadores!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar tipo de Trabajador",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego un nuevo Tipo de Trabajador con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public TipoTrabajadores Modificar(TipoTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.TipoTrabajadores.Attach(entidad);
            var entry = this.iConexion!.Entry<TipoTrabajadores>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Tipo de Trabajador",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico un Tipo de Trabajador con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public TipoTrabajadores Eliminar(TipoTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.TipoTrabajadores!.Remove(entidad);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Tipo de Trabajador",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino un Tipo de Trabajador con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}