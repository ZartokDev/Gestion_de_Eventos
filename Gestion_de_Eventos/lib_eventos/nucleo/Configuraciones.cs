namespace lib_eventos.nucleo
{
    public class Configuraciones
    {
        public static string? Obtener(string? clave)
        {
            return "server=localhost;database=DBeventos;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}
