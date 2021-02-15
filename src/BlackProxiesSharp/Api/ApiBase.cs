using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlackProxiesSharp.Exceptions;
using BlackProxiesSharp.Extensions;

namespace BlackProxiesSharp.Api
{
    public abstract class ApiBase
    {
        protected HttpClient HttpClient;

        protected virtual Dictionary<HttpStatusCode, Exception> StatusCodeExceptions { get; }

        internal ApiBase()
        {
        }

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        protected async Task<T> GetResponseAsync<T>(HttpRequestMessage requestMessage)
        {
            using var responseMessage = await HttpClient.SendAsync(requestMessage).ConfigureAwait(false);

            var statusCode = responseMessage.StatusCode;

            if (statusCode == HttpStatusCode.InternalServerError)
            {
                var json = await responseMessage.DeserializeJsonAsync<JsonElement>().ConfigureAwait(false);

                throw new Exception(json.GetProperty("error").GetString());
            }

            if (statusCode == HttpStatusCode.OK)
            {
                return await responseMessage.DeserializeJsonAsync<T>(_jsonSerializerOptions).ConfigureAwait(false);
            }

            if (StatusCodeExceptions != null && StatusCodeExceptions.TryGetValue(statusCode, out Exception ex))
            {
                throw ex;
            }

            throw new UnhandledStatusCodeException(statusCode);
        }
    }
}
