namespace lib_presentaciones.Interfaces
{
    public interface IComunicaciones
    {
        Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos);
    }
}
