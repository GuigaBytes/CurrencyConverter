using CurrencyConverter.Services;

namespace CurrencyConverter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: <amount> <fromCurrency> <toCurrency>");
                return;
            }

            decimal amount = Convert.ToDecimal(args[0]);
            string fromCurrency = args[1];
            string toCurrency = args[2];

            Console.WriteLine($"Converting {amount} {fromCurrency} to {toCurrency}...");

            decimal convertedAmount = await ExchangeRateService.ConvertCurrency(fromCurrency, toCurrency, amount);
            Console.WriteLine($"{amount} {fromCurrency} = {convertedAmount} {toCurrency}");
        }
    }
}
