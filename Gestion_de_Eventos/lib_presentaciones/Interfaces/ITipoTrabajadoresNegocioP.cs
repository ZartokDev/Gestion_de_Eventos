using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoTrabajadoresNegocioP
    {
        List<TipoTrabajadores> Consultar();
        TipoTrabajadores Guardar(TipoTrabajadores entidad);
        TipoTrabajadores Modificar(TipoTrabajadores entidad);
        TipoTrabajadores Eliminar(TipoTrabajadores entidad);
    }
}