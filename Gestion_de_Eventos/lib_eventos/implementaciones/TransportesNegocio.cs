using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class TransportesNegocio : ITransportesNegocio
    {
        private IConexion? iConexion;

        public List<Transportes> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Transportes!.ToList();
        }

        public Transportes Guardar(Transportes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Transportes!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}