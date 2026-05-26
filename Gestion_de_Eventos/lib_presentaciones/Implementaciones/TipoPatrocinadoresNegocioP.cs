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

    }
}
