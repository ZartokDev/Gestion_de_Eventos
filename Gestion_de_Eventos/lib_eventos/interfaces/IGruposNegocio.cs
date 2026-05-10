using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IGruposNegocio
    {
        List<Grupos> Consultar();
        Grupos Guardar(Grupos entidad);
    }
}