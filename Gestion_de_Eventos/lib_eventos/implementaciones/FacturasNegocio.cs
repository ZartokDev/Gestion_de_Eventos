using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class FacturasNegocio : IFacturasNegocio
    {
        private IConexion? iConexion;

        public List<Facturas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Factura",
                Descripcion = $"Se consulto una Factura",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.Facturas!.ToList();

        }

        public Facturas Guardar(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Facturas!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Factura",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego una nueva Factura con id: {entidad.Id} y numero de factura {entidad.NumFactura}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Facturas Modificar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Facturas.Attach(entidad);
            var entry = this.iConexion!.Entry<Facturas>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Cliente",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico una Factura con id: {entidad.Id} y numero de factura {entidad.NumFactura}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public Facturas Eliminar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var factura = this.iConexion.Eventos!.FirstOrDefault(e => e.Id == entidad.Id);

            if (factura == null)
                throw new Exception("El evento no existe");

            factura.Estado = false;
            this.iConexion.Eventos!.Update(factura);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Cliente",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino una Factura con id: {entidad.Id} y numero de factura {entidad.NumFactura}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}