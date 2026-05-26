using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITrabajadoresNegocioP
    {
        List<Trabajadores> Consultar();
        Trabajadores Guardar(Trabajadores entidad);
        Trabajadores Modificar(Trabajadores entidad);
        Trabajadores Eliminar(Trabajadores entidad);
    }
}