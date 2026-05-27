using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoPagosNegocio
    {
        List<TipoPagos> Consultar();
        TipoPagos Guardar(TipoPagos entidad);
        TipoPagos Modificar(TipoPagos entidad);
        TipoPagos Eliminar(TipoPagos entidad);
    }
}