using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface ITransportesNegocioP
    {
        List<Transportes> Consultar();
        Transportes Guardar(Transportes entidad);
        Transportes Modificar(Transportes entidad);
        Transportes Eliminar(Transportes entidad);
    }
}