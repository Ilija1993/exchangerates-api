using System.Collections.Generic;

namespace ExchangeRates.Service.Models
{
    public class ExchangeRatesResult
    {
        public string Base { get; set; }

        public string Date { get; set; }

        public Dictionary<string, decimal> Rates { get; set; }
    }
}
