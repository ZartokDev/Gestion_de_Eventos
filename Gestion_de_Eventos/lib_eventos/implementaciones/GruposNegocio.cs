using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class GruposNegocio : IGruposNegocio
    {
        private IConexion? iConexion;

        public List<Grupos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Grupos!.ToList();
        }

        public Grupos Guardar(Grupos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Grupos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}