namespace lib_presentaciones.Interfaces
{
    public interface IComunicaciones
    {
        Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> EjecutarPost(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> EjecutarPatch(Dictionary<string, object> datos);
        Task<Dictionary<string, object>> EjecutarDelete(Dictionary<string, object> datos);
    }
}
