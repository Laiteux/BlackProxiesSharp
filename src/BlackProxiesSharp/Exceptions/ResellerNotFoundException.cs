using System;

namespace BlackProxiesSharp.Exceptions
{
    public class ResellerNotFoundException : Exception
    {
        public ResellerNotFoundException() : base("No reseller found with this ID.")
        {
        }
    }
}
