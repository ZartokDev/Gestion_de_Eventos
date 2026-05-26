using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class PatrocinadoresNegocioP : IPatrocinadoresNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<Patrocinadores> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Patrocinadores/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Patrocinadores>();

            return JsonConvert.DeserializeObject<List<Patrocinadores>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Patrocinadores Guardar(Patrocinadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Patrocinadores/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Patrocinadores();

            return JsonConvert.DeserializeObject<Patrocinadores>(
                respuesta["Valor"].ToString()!)!;
        }

        public Patrocinadores Modificar(Patrocinadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Patrocinadores/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Patrocinadores();

            return JsonConvert.DeserializeObject<Patrocinadores>(
                respuesta["Valor"].ToString()!)!;
        }

        public Patrocinadores Eliminar(Patrocinadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Patrocinadores/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Patrocinadores();

            return JsonConvert.DeserializeObject<Patrocinadores>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
