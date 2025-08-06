using Xunit;
using DenskeFxExchange.Services;
using DenskeFxExchange.Interfaces;

namespace DenskeFxExchange.Tests;

public class CurrencyConverterTests
{
    private readonly CurrencyConverter _converter;

    public CurrencyConverterTests()
    {
        IExchangeRateProvider provider = new ExchangeRateProvider();
        _converter = new CurrencyConverter(provider);
    }

    [Fact]
    public void Converts_EUR_To_USD_Correctly()
    {
        var result = _converter.Convert("EUR", "USD", 100);
        Assert.True(result > 0);
    }

    [Fact]
    public void Returns_Same_For_Same_Currency()
    {
        var result = _converter.Convert("GBP", "GBP", 99);
        Assert.Equal(99, result);
    }

    [Fact]
    public void Throws_For_Unknown_Currency()
    {
        Assert.Throws<ArgumentException>(() => _converter.Convert("XYZ", "EUR", 10));
    }
}
