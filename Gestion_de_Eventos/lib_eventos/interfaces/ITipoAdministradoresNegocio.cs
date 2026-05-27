using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoAdministradoresNegocio
    {
        List<TipoAdministradores> Consultar();
        TipoAdministradores Guardar(TipoAdministradores entidad);
        TipoAdministradores Modificar(TipoAdministradores entidad);
        TipoAdministradores Eliminar(TipoAdministradores entidad);
    }
}