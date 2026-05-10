using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IClientesNegocio
    {
        List<Clientes> Consultar();
        Clientes Guardar(Clientes entidad);
    }
}