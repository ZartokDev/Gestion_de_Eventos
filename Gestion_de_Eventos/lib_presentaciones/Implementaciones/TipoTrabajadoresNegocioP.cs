using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;


namespace lib_presentaciones.Implementaciones
{
    public class TipoTrabajadoresNegocioP : ITipoTrabajadoresNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<TipoTrabajadores> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/TipoTrabajadores/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<TipoTrabajadores>();

            return JsonConvert.DeserializeObject<List<TipoTrabajadores>>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
