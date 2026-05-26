using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;


namespace lib_presentaciones.Implementaciones
{
    public class AdministradoresNegocioP : IAdministradoresNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<Administradores> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Administradores/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Administradores>();

            return JsonConvert.DeserializeObject<List<Administradores>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Administradores Guardar(Administradores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Administradores/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Administradores();

            return JsonConvert.DeserializeObject<Administradores>(
                respuesta["Valor"].ToString()!)!;
        }

        public Administradores Modificar(Administradores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Administradores/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Administradores();

            return JsonConvert.DeserializeObject<Administradores>(
                respuesta["Valor"].ToString()!)!;
        }

        public Administradores Eliminar(Administradores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Administradores/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Administradores();

            return JsonConvert.DeserializeObject<Administradores>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
