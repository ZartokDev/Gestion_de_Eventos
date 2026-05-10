using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IFacturasNegocio
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);
    }
}