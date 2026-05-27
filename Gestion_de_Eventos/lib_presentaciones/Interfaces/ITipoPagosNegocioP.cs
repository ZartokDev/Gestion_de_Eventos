using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoPagosNegocioP
    {
        List<TipoPagos> Consultar();
        TipoPagos Guardar(TipoPagos entidad);
        TipoPagos Modificar(TipoPagos entidad);
        TipoPagos Eliminar(TipoPagos entidad);
    }
}