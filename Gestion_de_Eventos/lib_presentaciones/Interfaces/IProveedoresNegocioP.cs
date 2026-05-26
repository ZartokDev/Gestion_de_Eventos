using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IProveedoresNegocioP
    {
        List<Proveedores> Consultar();
        Proveedores Guardar(Proveedores entidad);
        Proveedores Modificar(Proveedores entidad);
        Proveedores Eliminar(Proveedores entidad);
    }
}