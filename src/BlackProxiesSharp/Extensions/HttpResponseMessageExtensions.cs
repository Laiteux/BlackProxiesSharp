using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlackProxiesSharp.Extensions
{
    internal static class HttpResponseMessageExtensions
    {
        public static async Task<T> DeserializeJsonAsync<T>(this HttpResponseMessage httpResponseMessage, JsonSerializerOptions jsonSerializerOptions = null)
        {
            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(responseString, jsonSerializerOptions);
        }
    }
}
