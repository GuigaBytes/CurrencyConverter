using CurrencyConverter;

namespace CurrencyConverter.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("USD", true)]
        [InlineData("EUR", true)]
        [InlineData("usd", true)]
        [InlineData("EU", false)]
        [InlineData("EURO", false)]
        [InlineData("123", false)]
        public void IsCurrencyCodeValid_ReturnsExpectedResult(string code, bool expectedResult)
        {
            var result = Program.IsCurrencyCodeValid(code);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(new string[] { "USD", "EUR" }, true)]
        [InlineData(new string[] { "100", "USD", "EUR" }, true)]
        [InlineData(new string[] { }, false)]
        [InlineData(new string[] { "USD" }, false)]
        [InlineData(new string[] { "100", "USD", "EURO" }, false)]
        [InlineData(new string[] { "100", "USD" }, false)]
        [InlineData(new string[] { "USD", "123", "EUR" }, false)]
        [InlineData(new string[] { "USD", "EUR", "100" }, false)]
        public void ValidateArgs_ReturnsExpectedResult(string[] args, bool expectedResult)
        {
            var result = Program.ValidateArgs(args);
            Assert.Equal(expectedResult, result);
        }
    }
}
