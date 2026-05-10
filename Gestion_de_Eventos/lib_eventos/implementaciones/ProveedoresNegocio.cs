using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class ProveedoresNegocio : IProveedoresNegocio
    {
        private IConexion? iConexion;

        public List<Proveedores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Proveedores!.ToList();
        }

        public Proveedores Guardar(Proveedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Proveedores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}