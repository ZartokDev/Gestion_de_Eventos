using lib_eventos.entidades;

namespace lib_presentaciones.Interfaces
{
    public interface IPersonalApoyosNegocioP
    {
        List<PersonalApoyos> Consultar();
        PersonalApoyos Guardar(PersonalApoyos entidad);
        PersonalApoyos Modificar(PersonalApoyos entidad);
        PersonalApoyos Eliminar(PersonalApoyos entidad);
    }
}