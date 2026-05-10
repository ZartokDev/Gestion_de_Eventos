using lib_eventos.entidades;

namespace lib_eventos.interfaces
{
    public interface IPersonalApoyosNegocio
    {
        List<PersonalApoyos> Consultar();
        PersonalApoyos Guardar(PersonalApoyos entidad);
    }
}