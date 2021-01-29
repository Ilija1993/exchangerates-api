namespace ExchangeRates.Core.Models
{
    public class DateRate
    {
        public DateRate(string date, decimal rate)
        {
            Date = date;
            Rate = rate;
        }

        public DateRate()
        {

        }

        public string Date { get; set; }

        public decimal Rate { get; set; }
    }
}
