using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IPatrocinadoresNegocio
    {
        List<Patrocinadores> Consultar();
        Patrocinadores Guardar(Patrocinadores entidad);
    }
}