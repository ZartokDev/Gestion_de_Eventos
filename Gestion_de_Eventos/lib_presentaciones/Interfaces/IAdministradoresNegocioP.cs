using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IAdministradoresNegocioP
    {
        List<Administradores> Consultar();
        Administradores Guardar(Administradores entidad);
        Administradores Modificar(Administradores entidad);
        Administradores Eliminar(Administradores entidad);
    }
}