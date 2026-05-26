using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;

namespace lib_presentaciones.Implementaciones
{
    public class TipoPagosNegocioP : ITipoPagosNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<TipoPagos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoPagos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<TipoPagos>();

            return JsonConvert.DeserializeObject<List<TipoPagos>>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
