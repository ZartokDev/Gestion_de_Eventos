using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IHorariosNegocio
    {
        List<Horarios> Consultar();
        Horarios Guardar(Horarios entidad);
    }
}