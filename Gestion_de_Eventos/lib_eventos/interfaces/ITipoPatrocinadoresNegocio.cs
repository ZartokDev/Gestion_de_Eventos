using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITipoPatrocinadoresNegocio
    {
        List<TipoPatrocinadores> Consultar();
        TipoPatrocinadores Guardar(TipoPatrocinadores entidad);
        TipoPatrocinadores Modificar(TipoPatrocinadores entidad);
        TipoPatrocinadores Eliminar(TipoPatrocinadores entidad);
    }
}