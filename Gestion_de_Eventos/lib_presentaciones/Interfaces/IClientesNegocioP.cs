using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IClientesNegocioP
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        Clientes Eliminar(Clientes entidad);


    }
}