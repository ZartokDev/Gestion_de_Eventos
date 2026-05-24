using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IFacturasNegocioP
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);
    }
}