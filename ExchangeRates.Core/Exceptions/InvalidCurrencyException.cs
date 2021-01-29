using System.Net;

namespace ExchangeRates.Core.Exceptions
{
    public class InvalidCurrencyException : HttpException
    {
        public InvalidCurrencyException(string message) : base(HttpStatusCode.BadRequest, message)
        {

        }
    }
}
