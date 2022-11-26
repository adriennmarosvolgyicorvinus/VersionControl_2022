namespace MNB
{
    internal class GetExchangeRatesRequestBody
    {
        public GetExchangeRatesRequestBody()
        {
        }

        public string currencyNames { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}