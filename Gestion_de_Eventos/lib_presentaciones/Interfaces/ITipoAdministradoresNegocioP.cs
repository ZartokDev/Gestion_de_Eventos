using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoAdministradoresNegocioP
    {
        List<TipoAdministradores> Consultar();
        TipoAdministradores Guardar(TipoAdministradores entidad);
        TipoAdministradores Modificar(TipoAdministradores entidad);
        TipoAdministradores Eliminar(TipoAdministradores entidad);
    }
}