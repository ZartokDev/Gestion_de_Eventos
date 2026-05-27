using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class AuditoriasNegocio : IAuditoriasNegocio
    {
        private IConexion? iConexion;

        public List<Auditorias> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Auditoria",
                Descripcion = $"Se consulto una Auditoria",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.Auditorias!.ToList();
        }

        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Auditorias!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Cliente",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego una nueva Auditoria con id: {entidad.Id} y descripcion {entidad.Descripcion}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Auditorias.Attach(entidad);
            var entry = this.iConexion!.Entry<Auditorias>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Cliente",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico una Auditoria con id: {entidad.Id} con Descripcion {entidad.Descripcion}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public Auditorias Eliminar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Auditorias!.Remove(entidad);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Cliente",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino una Auditoria con id: {entidad.Id} con Descripcion {entidad.Descripcion}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }


    }
}