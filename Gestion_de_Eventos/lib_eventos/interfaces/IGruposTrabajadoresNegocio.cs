using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IGruposTrabajadoresNegocio
    {
        List<GruposTrabajadores> Consultar();
        GruposTrabajadores Guardar(GruposTrabajadores entidad);
        GruposTrabajadores Modificar(GruposTrabajadores entidad);
        GruposTrabajadores Eliminar(GruposTrabajadores entidad);
    }
}