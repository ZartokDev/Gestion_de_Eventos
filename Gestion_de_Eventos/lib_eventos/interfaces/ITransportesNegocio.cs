using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface ITransportesNegocio
    {
        List<Transportes> Consultar();
        Transportes Guardar(Transportes entidad);
        Transportes Modificar(Transportes entidad);
        Transportes Eliminar(Transportes entidad);
    }
}