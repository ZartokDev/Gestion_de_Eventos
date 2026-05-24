using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IProveedoresNegocioP
    {
        List<Proveedores> Consultar();
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Eliminar(Proveedores entidad);
    }
}