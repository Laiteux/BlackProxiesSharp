using System;

namespace BlackProxiesSharp.Exceptions
{
    public class PlanNotFoundException : Exception
    {
        public PlanNotFoundException() : base("No plan found with this ID.")
        {
        }
    }
}
