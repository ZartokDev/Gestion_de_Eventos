using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class AdministradoresNegocio : IAdministradoresNegocio
    {
        private IConexion? iConexion;

        public List<Administradores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Administradores!.ToList();
        }

        public Administradores Guardar(Administradores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Administradores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}