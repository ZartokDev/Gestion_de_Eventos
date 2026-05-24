using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class GruposTrabajadoresNegocio : IGruposTrabajadoresNegocio
    {
        private IConexion? iConexion;

        public List<GruposTrabajadores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Grupo de Trabajadores",
                Descripcion = $"Se consulto un Grupo de Trabajadores",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.GruposTrabajadores!.ToList();

        }

        public GruposTrabajadores Guardar(GruposTrabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.GruposTrabajadores!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Grupo de Trabajadores",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego un nuevo Grupo de Trabajadores con id: {entidad.Id}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public GruposTrabajadores Modificar(GruposTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.GruposTrabajadores.Attach(entidad);
            var entry = this.iConexion!.Entry<GruposTrabajadores>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Grupo de Trabajadores",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico un Grupo de Trabajadores con id: {entidad.Id}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public GruposTrabajadores Eliminar(GruposTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.GruposTrabajadores!.Remove(entidad);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Grupo de Trabajadores",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino un Grupo de Trabajadores con id: {entidad.Id}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}