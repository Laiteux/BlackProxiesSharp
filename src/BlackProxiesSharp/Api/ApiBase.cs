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

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };

        protected async Task<T> GetResponseAsync<T>(HttpRequestMessage requestMessage)
        {
            using var responseMessage = await HttpClient.SendAsync(requestMessage);

            var statusCode = responseMessage.StatusCode;

            if (statusCode != HttpStatusCode.OK)
            {
                if (StatusCodeExceptions != null && StatusCodeExceptions.TryGetValue(statusCode, out Exception ex))
                {
                    throw ex;
                }

                throw new UnhandledStatusCodeException(statusCode);
            }

            return await responseMessage.DeserializeJsonAsync<T>(_jsonSerializerOptions);
        }
    }
}
