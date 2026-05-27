using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class TipoTransportesNegocioP : ITipoTransportesNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<TipoTransportes> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTransportes/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<TipoTransportes>();

            return JsonConvert.DeserializeObject<List<TipoTransportes>>(
                respuesta["Valor"].ToString()!)!;
        }
        public TipoTransportes Guardar(TipoTransportes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTransportes/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new TipoTransportes();

            return JsonConvert.DeserializeObject<TipoTransportes>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoTransportes Modificar(TipoTransportes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTransportes/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoTransportes();

            return JsonConvert.DeserializeObject<TipoTransportes>(
                respuesta["Valor"].ToString()!)!;
        }

        public TipoTransportes Eliminar(TipoTransportes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTransportes/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new TipoTransportes();

            return JsonConvert.DeserializeObject<TipoTransportes>(
                respuesta["Valor"].ToString()!)!;
        }

    }
}
