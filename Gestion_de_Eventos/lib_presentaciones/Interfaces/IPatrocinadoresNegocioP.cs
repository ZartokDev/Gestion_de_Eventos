using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IPatrocinadoresNegocioP
    {
        List<Patrocinadores> Consultar();
        Patrocinadores Guardar(Patrocinadores entidad);
        Patrocinadores Modificar(Patrocinadores entidad);
        Patrocinadores Eliminar(Patrocinadores entidad);
    }
}