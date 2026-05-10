using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

Console.WriteLine("pre_consola");

IEventosNegocioP iEventosNegocio = new EventosNegocioP();
var lista = iEventosNegocio.Consultar();

foreach (var elemento in lista)
    Console.WriteLine(elemento.Nombre);