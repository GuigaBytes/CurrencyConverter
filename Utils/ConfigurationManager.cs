using Microsoft.Extensions.Configuration;

namespace CurrencyConverter.Utils
{
    public class ConfigurationManager
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();

            if (_configuration == null)
            {
                throw new InvalidOperationException("Failed to load configuration. Ensure the 'appsettings.json' file is present and properly formatted.");
            }
        }

        public string GetConfigurationValue(string key)
        {
            var value = _configuration[key];

            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"Configuration value not found for the specified key: {key}. Ensure the key is correct and has a value in 'appsettings.json'.");
            }

            return value;
        }
    }
}
