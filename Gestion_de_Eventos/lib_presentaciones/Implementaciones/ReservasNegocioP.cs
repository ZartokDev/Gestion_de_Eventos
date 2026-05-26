using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Newtonsoft.Json;


namespace lib_presentaciones.Implementaciones
{
    public class ReservasNegocioP : IReservasNegocioP
    {
        private IComunicaciones? iComunicaciones;

        public List<Reservas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Reservas/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Reservas>();

            return JsonConvert.DeserializeObject<List<Reservas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Reservas Guardar(Reservas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Reservas/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Reservas();

            return JsonConvert.DeserializeObject<Reservas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Reservas Modificar(Reservas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Reservas/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPatch(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Reservas();

            return JsonConvert.DeserializeObject<Reservas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Reservas Eliminar(Reservas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("El Id es necesario para modificar");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "https://localhost:7256/Reservas/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (respuesta == null || !respuesta.ContainsKey("Valor"))
                return new Reservas();

            return JsonConvert.DeserializeObject<Reservas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
