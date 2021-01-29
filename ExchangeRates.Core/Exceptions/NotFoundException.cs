using ExchangeRates.Core.Exceptions;
using System.Net;

namespace ExchangeRates.Service.Exceptions
{

    public class NotFoundException : HttpException
    {
        public NotFoundException(string message)
            : base(HttpStatusCode.NotFound, message)
        {
        }
    }
}
