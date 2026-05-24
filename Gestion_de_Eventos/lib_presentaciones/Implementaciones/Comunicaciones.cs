using lib_presentaciones.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace lib_presentaciones.Implementaciones
{
    public class Comunicaciones : IComunicaciones
    {
        public async Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos)
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
            return new Dictionary<string, object>() {
                { "Valor", resp }
            };
        }

        public async Task<Dictionary<string, object>> EjecutarPost(Dictionary<string, object> datos)
        {
            var url = datos["Url"].ToString();
            datos.Remove("Url");
            var stringData = datos.ContainsKey("Entidad") ?
                JsonConvert.SerializeObject(datos["Entidad"]) : "{}";
            var body = new StringContent(stringData, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 4, 0);

            var message = await httpClient.PostAsync(url, body);

            if (!message.IsSuccessStatusCode)
                throw new Exception("Error Comunicacion");

            var resp = await message.Content.ReadAsStringAsync();
            httpClient.Dispose(); httpClient = null;

            resp = Replace(resp);
            return new Dictionary<string, object>() {
                { "Valor", resp }
            };
        }

        public async Task<Dictionary<string, object>> EjecutarPatch(Dictionary<string, object> datos)
        {
            var url = datos["Url"].ToString();
            datos.Remove("Url");
            var stringData = datos.ContainsKey("Entidad") ?
                JsonConvert.SerializeObject(datos["Entidad"]) : "{}";
            var body = new StringContent(stringData, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 4, 0);

            var message = await httpClient.PatchAsync(url, body);

            if (!message.IsSuccessStatusCode)
                throw new Exception("Error Comunicacion");

            var resp = await message.Content.ReadAsStringAsync();
            httpClient.Dispose(); httpClient = null;

            resp = Replace(resp);
            return new Dictionary<string, object>() {
                { "Valor", resp }
            };
        }

        public async Task<Dictionary<string, object>> EjecutarDelete(Dictionary<string, object> datos)
        {
            var url = datos["Url"].ToString();
            datos.Remove("Url");
            var stringData = datos.ContainsKey("Entidad") ?
                JsonConvert.SerializeObject(datos["Entidad"]) : "{}";

            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 4, 0);

            var request = new HttpRequestMessage(HttpMethod.Delete, url)
            {
                Content = new StringContent(stringData, Encoding.UTF8, "application/json")
            };

            var message = await httpClient.SendAsync(request);

            if (!message.IsSuccessStatusCode)
                throw new Exception("Error Comunicación: " + message.StatusCode);

            var resp = await message.Content.ReadAsStringAsync();

            return new Dictionary<string, object>() {
            { "Valor", Replace(resp) }
        };
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
