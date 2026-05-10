using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IAdministradoresNegocio
    {
        List<Administradores> Consultar();
        Administradores Guardar(Administradores entidad);
    }
}