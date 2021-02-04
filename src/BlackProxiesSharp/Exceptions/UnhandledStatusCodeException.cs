using System;
using System.Net;

namespace BlackProxiesSharp.Exceptions
{
    public class UnhandledStatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public UnhandledStatusCodeException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
