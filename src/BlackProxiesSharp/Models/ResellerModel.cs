using System.Collections.Generic;

namespace BlackProxiesSharp.Models
{
    public class ResellerModel
    {
        public double Balance { get; set; }

        public List<PlanModel> Plans { get; set; }

        public List<string> Packages { get; set; }
    }
}
