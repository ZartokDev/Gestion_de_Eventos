using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class AuditoriasNegocioP : IAuditoriasNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<Auditorias> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Auditorias/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Auditorias>();

            return JsonConvert.DeserializeObject<List<Auditorias>>(
                respuesta["Valor"].ToString()!)!;
        }
        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Auditorias/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Auditorias/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }

        public Auditorias Eliminar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Auditorias/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
