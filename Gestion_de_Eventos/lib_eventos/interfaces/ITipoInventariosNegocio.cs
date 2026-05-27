using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoInventariosNegocio
    {
        List<TipoInventarios> Consultar();
        TipoInventarios Guardar(TipoInventarios entidad);
        TipoInventarios Modificar(TipoInventarios entidad);
        TipoInventarios Eliminar(TipoInventarios entidad);
    }
}