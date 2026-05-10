using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class GruposTrabajadoresNegocio : IGruposTrabajadoresNegocio
    {
        private IConexion? iConexion;

        public List<GruposTrabajadores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.GruposTrabajadores!.ToList();
        }

        public GruposTrabajadores Guardar(GruposTrabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.GruposTrabajadores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}