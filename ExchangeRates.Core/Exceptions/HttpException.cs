using System;
using System.Net;

namespace ExchangeRates.Core.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; private set; }

        public HttpException(HttpStatusCode statusCode, string exceptionMessage) : base(exceptionMessage)
        {
            StatusCode = statusCode;
        }
    }
}
