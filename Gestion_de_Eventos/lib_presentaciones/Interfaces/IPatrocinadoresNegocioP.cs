using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPatrocinadoresNegocioP
    {
        List<Patrocinadores> Consultar();
        Patrocinadores Guardar(Patrocinadores entidad);
        Patrocinadores Modificar(Patrocinadores entidad);
        Patrocinadores Eliminar(Patrocinadores entidad);
    }
}