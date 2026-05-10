using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;

Console.WriteLine("pre_consola");

var datos = new Dictionary<string, object>();
datos["Url"] = "http://localhost:5013/Eventos/Consultar";

var comunicaciones = new Comunicaciones();
var task = comunicaciones.Ejecutar<List<Eventos>>(datos)!;
task.Wait();
var respuesta = task.Result;