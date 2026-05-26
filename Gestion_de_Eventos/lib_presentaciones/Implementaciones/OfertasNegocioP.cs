using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;


namespace lib_presentaciones.Implementaciones
{
    public class OfertasNegocioP : IOfertasNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<Ofertas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Ofertas/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Ofertas>();

            return JsonConvert.DeserializeObject<List<Ofertas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Ofertas Guardar(Ofertas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Ofertas/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Ofertas();

            return JsonConvert.DeserializeObject<Ofertas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Ofertas Modificar(Ofertas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Ofertas/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Ofertas();

            return JsonConvert.DeserializeObject<Ofertas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Ofertas Eliminar(Ofertas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Ofertas/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Ofertas();

            return JsonConvert.DeserializeObject<Ofertas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
