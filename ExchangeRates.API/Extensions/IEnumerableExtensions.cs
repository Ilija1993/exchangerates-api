using System;
using System.Collections.Generic;

namespace ExchangeRates.API.Extensions
{
    public static class IEnumerableExtensions
    {
        public static List<DateTime> ConvertToDateTimeList(this string dates, char separator)
        {
            var converted = new List<DateTime>();

            var datesList = dates.Split(separator);

            foreach (var date in datesList)
            {
                converted.Add(DateTime.Parse(date));
            }

            return converted;
        }
    }
}
