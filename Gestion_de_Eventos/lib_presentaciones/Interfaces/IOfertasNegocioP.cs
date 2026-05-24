using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IOfertasNegocioP
    {
        List<Ofertas> Consultar();
        Ofertas Guardar(Ofertas entidad);
        Ofertas Modificar(Ofertas entidad);
        Ofertas Eliminar(Ofertas entidad);
    }
}