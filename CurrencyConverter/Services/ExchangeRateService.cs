﻿using CurrencyConverter.Models;
using CurrencyConverter.Utils;
using Newtonsoft.Json;

namespace CurrencyConverter.Services
{
    public class ExchangeRateService
    {
        public static async Task<decimal> ConvertCurrency(string from, string to, decimal amount)
        {
            decimal rate = await ExchangeRateService.GetCurrencyRate(from, to);

            return amount * rate;
        }

        public static async Task<decimal> GetCurrencyRate(string from, string to)
        {
            ConfigurationManager configManager = new ConfigurationManager();
            string apiKey = configManager.GetConfigurationValue("ApiKey");

            string url = $"https://v6.exchangerate-api.com/v6/{apiKey}/pair/{from}/{to}";

            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ExchangeRateResponse>(content) ?? throw new Exception("Failed to deserialize response");
            decimal rate = result.ConversionRate;

            return rate;
        }
    }
}
