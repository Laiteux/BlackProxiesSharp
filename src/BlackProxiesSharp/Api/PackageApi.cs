using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BlackProxiesSharp.Exceptions;
using BlackProxiesSharp.Models;
using BlackProxiesSharp.Utilities;

namespace BlackProxiesSharp.Api
{
    public class PackageApi : ApiBase
    {
        protected override Dictionary<HttpStatusCode, Exception> StatusCodeExceptions { get; } = new Dictionary<HttpStatusCode, Exception>()
        {
            { HttpStatusCode.NotFound, new PackageNotFoundException() }
        };

        public PackageApi(string id, HttpClient httpClient = null)
        {
            HttpClient = httpClient ?? new HttpClient();
            HttpClient.BaseAddress = new Uri($"https://proxies.black/api/package/{id}/");
        }

        public async Task<PackageModel> GetAsync()
            => await GetResponseAsync<PackageModel>(new HttpRequestMessage(HttpMethod.Get, string.Empty));

        public async Task<PackageModel> StartAsync(IEnumerable<string> ips)
            => await GetResponseAsync<PackageModel>(new HttpRequestMessage(HttpMethod.Post, "start")
            {
                Content = new JsonContent<IEnumerable<string>>(ips)
            });

        public async Task<IEnumerable<string>> GetProxiesAsync(string format = "host:port")
            => await GetResponseAsync<IEnumerable<string>>(new HttpRequestMessage(HttpMethod.Get, $"proxies?type=json&format={Uri.EscapeDataString(format)}"));

        public async Task<PackageModel> PauseAsync()
            => await GetResponseAsync<PackageModel>(new HttpRequestMessage(HttpMethod.Post, "pause"));

        public async Task<PackageModel> ResumeAsync()
            => await GetResponseAsync<PackageModel>(new HttpRequestMessage(HttpMethod.Post, "resume"));

        public async Task<PackageModel> RefreshPoolAsync()
            => await GetResponseAsync<PackageModel>(new HttpRequestMessage(HttpMethod.Post, "refresh"));

        public async Task<PackageModel> UpdateWhitelistedIPsAsync(IEnumerable<string> ips)
            => await GetResponseAsync<PackageModel>(new HttpRequestMessage(HttpMethod.Put, "ips")
            {
                Content = new JsonContent<IEnumerable<string>>(ips)
            });
    }
}
