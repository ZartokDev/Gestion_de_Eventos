using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class TransportesNegocio : ITransportesNegocio
    {
        private IConexion? iConexion;

        public List<Transportes> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Transporte",
                Descripcion = $"Se consulto un Transporte",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.Transportes!.ToList();

        }

        public Transportes Guardar(Transportes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Transportes!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Transporte",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego un nuevo Transporte con id: {entidad.Id} con Vehiculo {entidad.Vehiculo}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Transportes Modificar(Transportes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Transportes.Attach(entidad);
            var entry = this.iConexion!.Entry<Transportes>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Transporte",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico un Transporte con id: {entidad.Id} con Vehiculo {entidad.Vehiculo}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public Transportes Eliminar(Transportes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var transporte = this.iConexion.Eventos!.FirstOrDefault(e => e.Id == entidad.Id);

            if (transporte == null)
                throw new Exception("El evento no existe");

            transporte.Estado = false;
            this.iConexion.Eventos!.Update(transporte);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Transporte",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino un Transporte con id: {entidad.Id} con Vehiculo {entidad.Vehiculo}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}