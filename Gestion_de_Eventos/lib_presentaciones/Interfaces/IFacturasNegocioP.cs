using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IFacturasNegocioP
    {
        List<Facturas> Consultar();
        Facturas Guardar(Facturas entidad);
        Facturas Modificar(Facturas entidad);
        Facturas Eliminar(Facturas entidad);
    }
}