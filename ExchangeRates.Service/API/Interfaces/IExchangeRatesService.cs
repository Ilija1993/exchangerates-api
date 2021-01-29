using ExchangeRates.Core.Models;
using System.Threading.Tasks;

namespace ExchangeRates.Services.API.Interfaces
{
    public interface IExchangeRatesService
    {
        Task<ExchangeRateResponse> GetExchangeRatesAsync(ExchangeRatesRequest request);
    }
}
