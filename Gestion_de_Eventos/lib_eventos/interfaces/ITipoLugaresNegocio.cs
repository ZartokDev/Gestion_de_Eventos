using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoLugaresNegocio
    {
        List<TipoLugares> Consultar();
        TipoLugares Guardar(TipoLugares entidad);
        TipoLugares Modificar(TipoLugares entidad);
        TipoLugares Eliminar(TipoLugares entidad);
    }
}