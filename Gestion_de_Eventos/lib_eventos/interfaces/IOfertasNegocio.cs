using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IOfertasNegocio
    {
        List<Ofertas> Consultar();
        Ofertas Guardar(Ofertas entidad);
    }
}