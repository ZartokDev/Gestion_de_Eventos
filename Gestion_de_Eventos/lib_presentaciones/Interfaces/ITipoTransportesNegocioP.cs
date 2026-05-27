using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoTransportesNegocioP
    {
        List<TipoTransportes> Consultar();
        TipoTransportes Guardar(TipoTransportes entidad);
        TipoTransportes Modificar(TipoTransportes entidad);
        TipoTransportes Eliminar(TipoTransportes entidad);
    }
}