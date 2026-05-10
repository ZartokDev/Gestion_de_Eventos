using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class PersonalApoyosNegocio : IPersonalApoyosNegocio
    {
        private IConexion? iConexion;

        public List<PersonalApoyos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            return this.iConexion.PersonalApoyos!.ToList();
        }

        public PersonalApoyos Guardar(PersonalApoyos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.PersonalApoyos!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}