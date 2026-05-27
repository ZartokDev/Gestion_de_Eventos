using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoTrabajadoresNegocio
    {
        List<TipoTrabajadores> Consultar();
        TipoTrabajadores Guardar(TipoTrabajadores entidad);
        TipoTrabajadores Modificar(TipoTrabajadores entidad);
        TipoTrabajadores Eliminar(TipoTrabajadores entidad);
    }
}