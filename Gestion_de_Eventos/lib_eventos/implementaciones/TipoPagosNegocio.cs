using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class TipoPagosNegocio : ITipoPagosNegocio
    {
        private IConexion? iConexion;

        public List<TipoPagos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Tipo de Pago",
                Descripcion = $"Se consulto un Tipo de Pago",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.TipoPagos!.ToList();

        }

        public TipoPagos Guardar(TipoPagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.TipoPagos!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Cliente",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego un nuevo Tipo de Pago con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public TipoPagos Modificar(TipoPagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.TipoPagos.Attach(entidad);
            var entry = this.iConexion!.Entry<TipoPagos>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Tipo de Pago",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico un Tipo de Pago con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public TipoPagos Eliminar(TipoPagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.TipoPagos!.Remove(entidad);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Tipo de Pago",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino un Tipo de Pago con id: {entidad.Id} con nombre {entidad.Nombre}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}