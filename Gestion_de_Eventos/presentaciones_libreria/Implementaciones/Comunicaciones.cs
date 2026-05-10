using Newtonsoft.Json;
using System.Text;

namespace lib_presentaciones.Implementaciones
{
    public class Comunicaciones
    {
        public async Task<T> Ejecutar<T>(Dictionary<string, object> datos)
        {
            var url = datos["Url"].ToString();
            datos.Remove("Url");
            var stringData = datos.ContainsKey("Entidad") ?
                JsonConvert.SerializeObject(datos["Entidad"]) : "{}";
            var body = new StringContent(stringData, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 4, 0);

            var message = await httpClient.GetAsync(url);

            if (!message.IsSuccessStatusCode)
                throw new Exception("Error Comunicacion");

            var resp = await message.Content.ReadAsStringAsync();
            httpClient.Dispose(); httpClient = null;

            resp = Replace(resp);
            return JsonConvert.DeserializeObject<T>(resp)!;
        }

        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
                .Replace("\\r\\n", "")
                .Replace("\\", "")
                .Replace("\\\"", "\"")
                .Replace("\"", "'")
                .Replace("'[", "[")
                .Replace("]'", "]")
                .Replace("'{'", "{'")
                .Replace("\\\\", "\\")
                .Replace("'}'", "'}")
                .Replace("}'", "}")
                .Replace("\\n", "")
                .Replace("\\r", "")
                .Replace("    ", "")
                .Replace("'{", "{")
                .Replace("\"", "")
                .Replace("  ", "")
                .Replace("null", "''");
        }
    }
}
