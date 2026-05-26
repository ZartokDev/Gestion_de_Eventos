using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;


namespace lib_presentaciones.Implementaciones
{
    public class PersonalApoyosNegocioP : IPersonalApoyosNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<PersonalApoyos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/PersonalApoyos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<PersonalApoyos>();

            return JsonConvert.DeserializeObject<List<PersonalApoyos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonalApoyos Guardar(PersonalApoyos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/PersonalApoyos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new PersonalApoyos();

            return JsonConvert.DeserializeObject<PersonalApoyos>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonalApoyos Modificar(PersonalApoyos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/PersonalApoyos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new PersonalApoyos();

            return JsonConvert.DeserializeObject<PersonalApoyos>(
                respuesta["Valor"].ToString()!)!;
        }

        public PersonalApoyos Eliminar(PersonalApoyos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/PersonalApoyos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new PersonalApoyos();

            return JsonConvert.DeserializeObject<PersonalApoyos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
