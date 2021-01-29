namespace ExchangeRates.Core.Models
{
    public class ExchangeRateResponse
    {
        public DateRate MinRate { get; private set; }

        public DateRate MaxRate { get; private set; }

        public decimal AverageRate { get; private set; }

        public ExchangeRateResponse(DateRate minRate, DateRate maxRate, decimal average)
        {
            MinRate = minRate;
            MaxRate = maxRate;
            AverageRate = average;
        }
    }
}
