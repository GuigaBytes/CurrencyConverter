using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace CurrencyConverter
{
    class Program
    {
        public static IConfiguration? Configuration { get; set; }
        public static string? apiKey;

        static async Task Main(string[] args)
        {
            apiKey = GetApiKey();

            if (apiKey == null)
            {
                throw new Exception("API key not found");
            }

            if (args.Length != 3)
            {
                Console.WriteLine("Usage: <amount> <fromCurrency> <toCurrency>");
                return;
            }

            decimal amount = Convert.ToDecimal(args[0]);
            string fromCurrency = args[1];
            string toCurrency = args[2];

            Console.WriteLine($"Converting {amount} {fromCurrency} to {toCurrency}...");
            decimal convertedAmount = await ConvertCurrency(fromCurrency, toCurrency, amount);
            Console.WriteLine($"{amount} {fromCurrency} = {convertedAmount} {toCurrency}");
        }

        static async Task<decimal> ConvertCurrency(string from, string to, decimal amount)
        {
            string url = $"https://v6.exchangerate-api.com/v6/{apiKey}/pair/{from}/{to}";

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ExchangeRateResponse>(content);

                decimal rate = result.ConversionRate;
                return amount * rate;
            }
        }

        static string GetApiKey()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            if (Configuration == null)
            {
                throw new Exception("Configuration not loaded");
            }

            return Configuration["ApiKey"];
        }
    }

    public class ExchangeRateResponse
    {
        [JsonProperty("conversion_rate")]
        public decimal ConversionRate { get; set; }
    }
}
