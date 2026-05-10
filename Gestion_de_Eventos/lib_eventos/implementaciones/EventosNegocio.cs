using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class EventosNegocio : IEventosNegocio
    {
        private IConexion? iConexion;

        public List<Eventos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            return this.iConexion.Eventos!.ToList();
        }

        public Eventos Guardar(Eventos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Eventos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}