using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IInventariosNegocio
    {
        List<Inventarios> Consultar();
        Inventarios Guardar(Inventarios entidad);
        Inventarios Modificar(Inventarios entidad);
        Inventarios Eliminar(Inventarios entidad);
    }
}