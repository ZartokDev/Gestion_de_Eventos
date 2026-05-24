using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IPersonalApoyosNegocioP
    {
        List<PersonalApoyos> Consultar();
        PersonalApoyos Guardar(PersonalApoyos entidad);
        PersonalApoyos Modificar(PersonalApoyos entidad);
        PersonalApoyos Eliminar(PersonalApoyos entidad);
    }
}