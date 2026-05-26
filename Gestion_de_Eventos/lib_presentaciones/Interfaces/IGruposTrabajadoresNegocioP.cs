using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IGruposTrabajadoresNegocioP
    {
        List<GruposTrabajadores> Consultar();
        GruposTrabajadores Guardar(GruposTrabajadores entidad);
        GruposTrabajadores Modificar(GruposTrabajadores entidad);
        GruposTrabajadores Eliminar(GruposTrabajadores entidad);
    }
}