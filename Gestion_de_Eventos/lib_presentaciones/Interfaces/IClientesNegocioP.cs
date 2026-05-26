using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IClientesNegocioP
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        Clientes Eliminar(Clientes entidad);


    }
}