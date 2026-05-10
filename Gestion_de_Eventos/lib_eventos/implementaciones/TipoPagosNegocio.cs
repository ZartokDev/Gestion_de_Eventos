using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class TipoPagosNegocio : ITipoPagosNegocio
    {
        private IConexion? iConexion;

        public List<TipoPagos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.TipoPagos!.ToList();
        }

        public TipoPagos Guardar(TipoPagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.TipoPagos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}