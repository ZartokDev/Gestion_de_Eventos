using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoLugaresNegocioP
    {
        List<TipoLugares> Consultar();
        TipoLugares Guardar(TipoLugares entidad);
        TipoLugares Modificar(TipoLugares entidad);
        TipoLugares Eliminar(TipoLugares entidad);
    }
}