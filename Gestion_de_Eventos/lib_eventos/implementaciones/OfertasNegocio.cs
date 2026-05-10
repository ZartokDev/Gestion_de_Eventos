using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class OfertasNegocio : IOfertasNegocio
    {
        private IConexion? iConexion;

        public List<Ofertas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.Ofertas!.ToList();
        }

        public Ofertas Guardar(Ofertas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Ofertas!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}