using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;


namespace lib_presentaciones.Implementaciones
{
    public class TipoTrabajadoresNegocioP : ITipoTrabajadoresNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<TipoTrabajadores> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTrabajadores/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<TipoTrabajadores>();

            return JsonConvert.DeserializeObject<List<TipoTrabajadores>>(
                respuesta["Valor"].ToString()!)!;
        }
        public TipoTrabajadores Guardar(TipoTrabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTrabajadores/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new TipoTrabajadores();

            return JsonConvert.DeserializeObject<TipoTrabajadores>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoTrabajadores Modificar(TipoTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTrabajadores/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoTrabajadores();

            return JsonConvert.DeserializeObject<TipoTrabajadores>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoTrabajadores Eliminar(TipoTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTrabajadores/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoTrabajadores();

            return JsonConvert.DeserializeObject<TipoTrabajadores>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
