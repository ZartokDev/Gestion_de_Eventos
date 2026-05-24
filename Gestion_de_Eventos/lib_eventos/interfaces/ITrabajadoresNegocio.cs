using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITrabajadoresNegocio
    {
        List<Trabajadores> Consultar();
        Trabajadores Guardar(Trabajadores entidad);
        Trabajadores Modificar(Trabajadores entidad);
        Trabajadores Eliminar(Trabajadores entidad);
    }
}