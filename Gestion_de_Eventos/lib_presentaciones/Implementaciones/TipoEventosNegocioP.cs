using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class TipoEventosNegocioP : ITipoEventosNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<TipoEventos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoEventos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<TipoEventos>();

            return JsonConvert.DeserializeObject<List<TipoEventos>>(
                respuesta["Valor"].ToString()!)!;
        }

    }
}
