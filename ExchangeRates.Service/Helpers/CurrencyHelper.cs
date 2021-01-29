using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeRates.Service.Helpers
{
    public static class CurrencyHelper
    {
        public static HashSet<string> GetAvailableCurrencies()
        {
            return new HashSet<string>
            {
                "USD","JPY","BGN","CZK","DKK","GBP","HUF","PLN",
                "SEK","CHF","ISK","NOK","HRK","RUB","TRY","AUD",
                "BRL","CAD","CNY","HKD","IDR","ILS","INR","KRW",
                "MXN","MYR","NZD","PHP","SGD","THB","ZAR","RON"
            };
        }
    }
}
