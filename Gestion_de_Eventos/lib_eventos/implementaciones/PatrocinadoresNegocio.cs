using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class PatrocinadoresNegocio : IPatrocinadoresNegocio
    {
        private IConexion? iConexion;

        public List<Patrocinadores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Patrocinadores!.ToList();
        }

        public Patrocinadores Guardar(Patrocinadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Patrocinadores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}