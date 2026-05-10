using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class HorariosNegocio : IHorariosNegocio
    {
        private IConexion? iConexion;

        public List<Horarios> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Horarios!.ToList();
        }

        public Horarios Guardar(Horarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Horarios!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}