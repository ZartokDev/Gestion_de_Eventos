using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class TipoInventariosNegocioP : ITipoInventariosNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<TipoInventarios> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoInventarios/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<TipoInventarios>();

            return JsonConvert.DeserializeObject<List<TipoInventarios>>(
                respuesta["Valor"].ToString()!)!;
        }
        public TipoInventarios Guardar(TipoInventarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoInventarios/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new TipoInventarios();

            return JsonConvert.DeserializeObject<TipoInventarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoInventarios Modificar(TipoInventarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoInventarios/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoInventarios();

            return JsonConvert.DeserializeObject<TipoInventarios>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoInventarios Eliminar(TipoInventarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoInventarios/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoInventarios();

            return JsonConvert.DeserializeObject<TipoInventarios>(
                respuesta["Valor"].ToString()!)!;
        }

    }
}
