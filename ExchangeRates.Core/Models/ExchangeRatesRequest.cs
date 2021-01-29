using System;
using System.Collections.Generic;

namespace ExchangeRates.Core.Models
{
    public class ExchangeRatesRequest
    {
        public string BaseCurrency { get; set; }

        public string TargetCurrency { get; set; }

        public List<DateTime> Dates { get; set; }
    }
}
