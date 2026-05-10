using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class TipoEventosNegocio : ITipoEventosNegocio
    {
        private IConexion? iConexion;

        public List<TipoEventos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.TipoEventos!.ToList();
        }

        public TipoEventos Guardar(TipoEventos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.TipoEventos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}