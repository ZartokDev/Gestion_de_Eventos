using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ILugaresNegocioP
    {
        List<Lugares> Consultar();
        Lugares Guardar(Lugares entidad);
        Lugares Modificar(Lugares entidad);
        Lugares Eliminar(Lugares entidad);
    }
}