using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BlackProxiesSharp.Utilities
{
    internal class JsonContent<T> : StringContent
    {
        public JsonContent(T content, JsonSerializerOptions options = null)
            : base(JsonSerializer.Serialize(content, options), Encoding.UTF8, "application/json")
        {
        }
    }
}
