using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IGruposNegocioP
    {
        List<Grupos> Consultar();
        Grupos Guardar(Grupos entidad);
        Grupos Modificar(Grupos entidad);
        Grupos Eliminar(Grupos entidad);
    }
}