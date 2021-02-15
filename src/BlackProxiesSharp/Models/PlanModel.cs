using System.Text.Json.Serialization;

namespace BlackProxiesSharp.Models
{
    public class PlanModel
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public int IncludedTrafficGB { get; set; }

        public double PricePerAdditional50GB { get; set; }

        public int FreePauses { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public BillingType Billing { get; set; }

        public int ProxyCount { get; set; }

        public int AccessIPs { get; set; }

        public int Threads { get; set; }
    }

    public enum BillingType
    {
        Hourly,
        Daily,
        Weekly,
        Monthly
    }
}
