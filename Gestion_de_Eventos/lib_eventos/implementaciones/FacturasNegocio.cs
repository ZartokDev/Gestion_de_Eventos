using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

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
    }
}