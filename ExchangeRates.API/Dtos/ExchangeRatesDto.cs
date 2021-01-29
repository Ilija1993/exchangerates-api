namespace ExchangeRates.API.Dtos
{
    public class ExchangeRatesDto
    {
        public string Dates { get; set; }

        public string BaseCurrency { get; set; }

        public string TargetCurrency { get; set; }
    }
}
