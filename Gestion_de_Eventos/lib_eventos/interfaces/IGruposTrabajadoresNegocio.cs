using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IGruposTrabajadoresNegocio
    {
        List<GruposTrabajadores> Consultar();
        GruposTrabajadores Guardar(GruposTrabajadores entidad);
    }
}