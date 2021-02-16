using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlackProxiesSharp.Exceptions;
using BlackProxiesSharp.Models;

namespace BlackProxiesSharp.Api
{
    public class ResellerApi : ApiBase
    {
        protected override Dictionary<HttpStatusCode, Exception> StatusCodeExceptions { get; } = new Dictionary<HttpStatusCode, Exception>()
        {
            { HttpStatusCode.Unauthorized, new ResellerNotFoundException() },
            { HttpStatusCode.NotFound, new PlanNotFoundException() },
            { HttpStatusCode.PaymentRequired, new NotEnoughBalanceException() }
        };

        public ResellerApi(string id, HttpClient httpClient = null)
        {
            HttpClient = httpClient ?? new HttpClient();
            HttpClient.BaseAddress = new Uri($"https://proxies.black/api/reseller/{id}/");
        }

        public async Task<ResellerModel> GetAsync()
            => await GetResponseAsync<ResellerModel>(new HttpRequestMessage(HttpMethod.Get, string.Empty)).ConfigureAwait(false);

        /// <returns>Payment URL</returns>
        public async Task<string> DepositAsync(double amount)
            => (await GetResponseAsync<JsonElement>(new HttpRequestMessage(HttpMethod.Post, "deposit")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "amount", amount.ToString("0.00") }
                })
            }).ConfigureAwait(false)).GetProperty("url").GetString();

        /// <returns>Package ID</returns>
        public async Task<string> PurchasePackageAsync(int planId, int additionalTrafficGB = 0)
            => (await GetResponseAsync<JsonElement>(new HttpRequestMessage(HttpMethod.Post, "purchase")
            {
                Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "planId", planId.ToString() },
                    { "additionalTrafficGB", additionalTrafficGB.ToString() }
                })
            }).ConfigureAwait(false)).GetProperty("package").GetString();

        /// <returns>Package ID</returns>
        public async Task<string> PurchasePackageAsync(PlanModel plan, int additionalTrafficGB = 0)
            => await PurchasePackageAsync(plan.Id, additionalTrafficGB).ConfigureAwait(false);
    }
}
