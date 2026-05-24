using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IHorariosNegocioP
    {
        List<Horarios> Consultar();
        Horarios Guardar(Horarios entidad);
        Horarios Modificar(Horarios entidad);
        Horarios Eliminar(Horarios entidad);
    }
}