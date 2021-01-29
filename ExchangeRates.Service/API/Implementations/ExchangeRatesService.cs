using ExchangeRates.Core.Exceptions;
using ExchangeRates.Core.Models;
using ExchangeRates.Core.Settings;
using ExchangeRates.Service.Exceptions;
using ExchangeRates.Service.Helpers;
using ExchangeRates.Service.Models;
using ExchangeRates.Services.API.Interfaces;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Services.API.Implementations
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly RestClient _client;
        private readonly HashSet<string> _currencies;

        public ExchangeRatesService(IOptions<ConnectionSettings> settings)
        {
            _client = new RestClient(settings.Value.Url);
            _currencies = CurrencyHelper.GetAvailableCurrencies();
        }

        public async Task<ExchangeRateResponse> GetExchangeRatesAsync(ExchangeRatesRequest request)
        {
            ValidateCurrencies(request.BaseCurrency, request.TargetCurrency);

            var tasks = new List<Task<ExchangeRatesResult>>();

            request.Dates.ForEach(date =>
            {
                tasks.Add(GetExchangeRatesAsync(date, request.BaseCurrency, request.TargetCurrency));
            });
           
            var result = await Task.WhenAll(tasks);
         
            if (result == null || result.Length == 0)
            {
                throw new NotFoundException("There are no exchange rates for provided dates.");
            }

            var rateDates = result.Select(res => new DateRate(res.Date, res.Rates.Values.First())).OrderBy(r => r.Rate).ToList();

            var minRate = rateDates.FirstOrDefault();
            var maxRate = rateDates.LastOrDefault();
            var average = rateDates.Average(rd => rd.Rate);

            return new ExchangeRateResponse(minRate, maxRate, average);
        }

        private Task<ExchangeRatesResult> GetExchangeRatesAsync(DateTime date, string baseCurrency, string targetCurrency)
        {
            var resource = CreateResource(date,baseCurrency, targetCurrency);

            var request = new RestRequest(resource, Method.GET, DataFormat.Json);

            return _client.GetAsync<ExchangeRatesResult>(request);
        }

        private string CreateResource(DateTime date, string baseCurrency, string targetCurrency)
        {
            var bulder = new StringBuilder()
                  .Append($"/{date:yyyy-MM-dd}")
                  .Append($"?base={baseCurrency}")
                  .Append($"&symbols={targetCurrency}");

            return bulder.ToString();
        }

        private void ValidateCurrencies(string baseCurrency, string targetCurrency)
        {
            if (!_currencies.Contains(baseCurrency) || !_currencies.Contains(targetCurrency))
            {
                throw new InvalidCurrencyException($"Currencies: {baseCurrency} or {targetCurrency} are not vaild. Valid currencies are: {string.Join(',', _currencies)}");
            }
        }
    }
}
