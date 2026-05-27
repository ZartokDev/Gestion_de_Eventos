using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class TipoAdministradoresNegocioP : ITipoAdministradoresNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<TipoAdministradores> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoAdministradores/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<TipoAdministradores>();

            return JsonConvert.DeserializeObject<List<TipoAdministradores>>(
                respuesta["Valor"].ToString()!)!;
        }
        public TipoAdministradores Guardar(TipoAdministradores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoAdministradores/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new TipoAdministradores();

            return JsonConvert.DeserializeObject<TipoAdministradores>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoAdministradores Modificar(TipoAdministradores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoAdministradores/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoAdministradores();

            return JsonConvert.DeserializeObject<TipoAdministradores>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoAdministradores Eliminar(TipoAdministradores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoAdministradores/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoAdministradores();

            return JsonConvert.DeserializeObject<TipoAdministradores>(
                respuesta["Valor"].ToString()!)!;
        }

    }
}
