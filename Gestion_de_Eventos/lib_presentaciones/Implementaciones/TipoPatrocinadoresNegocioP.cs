using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class TipoPatrocinadoresNegocioP : ITipoPatrocinadoresNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<TipoPatrocinadores> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoPatrocinadores/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<TipoPatrocinadores>();

            return JsonConvert.DeserializeObject<List<TipoPatrocinadores>>(
                respuesta["Valor"].ToString()!)!;
        }
        public TipoPatrocinadores Guardar(TipoPatrocinadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoPatrocinadores/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new TipoPatrocinadores();

            return JsonConvert.DeserializeObject<TipoPatrocinadores>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoPatrocinadores Modificar(TipoPatrocinadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoPatrocinadores/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoPatrocinadores();

            return JsonConvert.DeserializeObject<TipoPatrocinadores>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoPatrocinadores Eliminar(TipoPatrocinadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoPatrocinadores/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoPatrocinadores();

            return JsonConvert.DeserializeObject<TipoPatrocinadores>(
                respuesta["Valor"].ToString()!)!;
        }

    }
}
