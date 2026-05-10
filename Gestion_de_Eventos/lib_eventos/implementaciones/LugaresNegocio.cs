using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class LugaresNegocio : ILugaresNegocio
    {
        private IConexion? iConexion;

        public List<Lugares> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Lugares!.ToList();
        }

        public Lugares Guardar(Lugares entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Lugares!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}