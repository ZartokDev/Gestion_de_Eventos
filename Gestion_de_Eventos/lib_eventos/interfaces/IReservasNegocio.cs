using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IReservasNegocio
    {
        List<Reservas> Consultar();
        Reservas Guardar(Reservas entidad);
    }
}