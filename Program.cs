using CurrencyConverter.Services;

namespace CurrencyConverter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (!ValidateArgs(args))
            {
                Console.WriteLine("Invalid arguments. Please use the correct format.");
                Console.WriteLine("Usage: <amount> <fromCurrency> <toCurrency>");
                Console.WriteLine("Or: <fromCurrency> <toCurrency> (with default amount of 1)");
                return;
            }

            decimal amount = args.Length == 3 ? Convert.ToDecimal(args[0]) : 1;
            string fromCurrency = args[^2].ToUpper();
            string toCurrency = args[^1].ToUpper();

            Console.WriteLine($"\n[CONVERTING]: {amount} {fromCurrency} to {toCurrency}...\n");

            decimal convertedAmount = await ExchangeRateService.ConvertCurrency(fromCurrency, toCurrency, amount);
            
            if (amount > 1)
            {
                Console.WriteLine($"[RESULT]: {amount} {fromCurrency} = {convertedAmount} {toCurrency}\n");
            }
        }

        private static bool ValidateArgs(string[] args)
        {
            if (args.Length < 2 || args.Length > 3)
            {
                return false;
            }

            if (args.Length == 3 && !decimal.TryParse(args[0], out _))
            {
                return false;
            }

            if (!IsCurrencyCodeValid(args[^2]) || !IsCurrencyCodeValid(args[^1]))
            {
                return false;
            }

            return true;
        }

        private static bool IsCurrencyCodeValid(string code)
        {
            return code.Length == 3 && code.All(char.IsLetter);
        }
    }
}
