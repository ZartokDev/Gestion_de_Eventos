using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class TipoPatrocinadoresNegocio : ITipoPatrocinadoresNegocio
    {
        private IConexion? iConexion;

        public List<TipoPatrocinadores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.TipoPatrocinadores!.ToList();
        }

        public TipoPatrocinadores Guardar(TipoPatrocinadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.TipoPatrocinadores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}