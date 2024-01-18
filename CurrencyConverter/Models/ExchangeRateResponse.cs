using Newtonsoft.Json;

namespace CurrencyConverter.Models
{
    public class ExchangeRateResponse
    {
        [JsonProperty("conversion_rate")]
        public decimal ConversionRate { get; set; }
    }
}
