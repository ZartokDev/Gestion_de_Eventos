using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ILugaresNegocio
    {
        List<Lugares> Consultar();
        Lugares Guardar(Lugares entidad);
    }
}