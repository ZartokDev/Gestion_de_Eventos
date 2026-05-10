using lib_eventos.interfaces;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class EventosNegocioP : IEventosNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<Eventos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5188/Eventos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Eventos>();

            return JsonConvert.DeserializeObject<List<Eventos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Eventos Guardar(Eventos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5188/Eventos/Guardar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Eventos();

            return JsonConvert.DeserializeObject<Eventos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
