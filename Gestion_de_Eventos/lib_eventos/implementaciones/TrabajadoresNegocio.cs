using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class TrabajadoresNegocio : ITrabajadoresNegocio
    {
        private IConexion? iConexion;

        public List<Trabajadores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Trabajadores!.ToList();
        }

        public Trabajadores Guardar(Trabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Trabajadores!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}