using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;


namespace lib_presentaciones.Implementaciones
{
    public class GruposTrabajadoresNegocioP : IGruposTrabajadoresNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<GruposTrabajadores> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/GruposTrabajadores/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<GruposTrabajadores>();

            return JsonConvert.DeserializeObject<List<GruposTrabajadores>>(
                respuesta["Valor"].ToString()!)!;
        }

        public GruposTrabajadores Guardar(GruposTrabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/GruposTrabajadores/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new GruposTrabajadores();

            return JsonConvert.DeserializeObject<GruposTrabajadores>(
                respuesta["Valor"].ToString()!)!;
        }

        public GruposTrabajadores Modificar(GruposTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/GruposTrabajadores/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new GruposTrabajadores();

            return JsonConvert.DeserializeObject<GruposTrabajadores>(
                respuesta["Valor"].ToString()!)!;
        }

        public GruposTrabajadores Eliminar(GruposTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/GruposTrabajadores/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new GruposTrabajadores();

            return JsonConvert.DeserializeObject<GruposTrabajadores>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
