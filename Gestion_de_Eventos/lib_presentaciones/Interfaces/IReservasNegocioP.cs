using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IReservasNegocioP
    {
        List<Reservas> Consultar();
        Reservas Guardar(Reservas entidad);
        Reservas Modificar(Reservas entidad);
        Reservas Eliminar(Reservas entidad);
    }
}