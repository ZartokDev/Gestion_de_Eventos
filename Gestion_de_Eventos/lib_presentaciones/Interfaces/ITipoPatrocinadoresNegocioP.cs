using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITipoPatrocinadoresNegocioP
    {
        List<TipoPatrocinadores> Consultar();
        TipoPatrocinadores Guardar(TipoPatrocinadores entidad);
        TipoPatrocinadores Modificar(TipoPatrocinadores entidad);
        TipoPatrocinadores Eliminar(TipoPatrocinadores entidad);
    }
}