using System;

namespace BlackProxiesSharp.Exceptions
{
    public class PackageNotFoundException : Exception
    {
        public PackageNotFoundException() : base("No package found with this ID.")
        {
        }
    }
}
