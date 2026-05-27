using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoTransportesNegocio
    {
        List<TipoTransportes> Consultar();
        TipoTransportes Guardar(TipoTransportes entidad);
        TipoTransportes Modificar(TipoTransportes entidad);
        TipoTransportes Eliminar(TipoTransportes entidad);
    }
}