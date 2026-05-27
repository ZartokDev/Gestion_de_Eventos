using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoInventariosNegocioP
    {
        List<TipoInventarios> Consultar();
        TipoInventarios Guardar(TipoInventarios entidad);
        TipoInventarios Modificar(TipoInventarios entidad);
        TipoInventarios Eliminar(TipoInventarios entidad);
    }
}