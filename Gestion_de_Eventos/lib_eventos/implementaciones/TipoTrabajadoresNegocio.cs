using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class TipoTrabajadoresNegocio : ITipoTrabajadoresNegocio
    {
        private IConexion? iConexion;

        public List<TipoTrabajadores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.TipoTrabajadores!.ToList();
        }

        public TipoTrabajadores Guardar(TipoTrabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.TipoTrabajadores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}