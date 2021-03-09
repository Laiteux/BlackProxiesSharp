using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BlackProxiesSharp.Utilities;

namespace BlackProxiesSharp.Models
{
    public class PackageModel
    {
        public string Plan { get; set; }

        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTimeOffset StartedAt { get; set; }

        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTimeOffset ExpiresAt { get; set; }

        public bool Deactivated { get; set; }

        public PackageTrafficModel Traffic { get; set; }

        public PackageThreadsModel Threads { get; set; }

        public PackagePausesModel Pauses { get; set; }

        public PackageIPsModel IPs { get; set; }

        public List<string> Proxies { get; set; }

        public bool Expired => DateTimeOffset.Now > ExpiresAt;
    }

    public class PackageTrafficModel
    {
        public long Limit { get; set; }

        public long Used { get; set; }

        public long Day { get; set; }

        public long Week { get; set; }

        public long Month { get; set; }
    }

    public class PackageThreadsModel
    {
        public int Limit { get; set; }

        public int Active { get; set; }
    }

    public class PackagePausesModel
    {
        public int Limit { get; set; }

        public int Used { get; set; }

        public bool IsPaused { get; set; }
    }

    public class PackageIPsModel
    {
        public int Limit { get; set; }

        public List<string> Whitelist { get; set; }
    }
}
