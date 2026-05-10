using lib_eventos.implementaciones;
using lib_eventos.interfaces;

Console.WriteLine("cns_presentacion");
Console.WriteLine("Conexion de Base de datos");

IConexion conexion = new Conexion();
conexion.StringConexion = "server=localhost\\DEV;Integrated Security=True;TrustServerCertificate=true;database=DBeventos;";
var lista_eventos = conexion.Eventos!.ToList();

Console.WriteLine("Final");