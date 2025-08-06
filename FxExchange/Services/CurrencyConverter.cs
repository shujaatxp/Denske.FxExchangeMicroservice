using DenskeFxExchange.Interfaces;

namespace DenskeFxExchange.Services;

public class CurrencyConverter
{
    private readonly IExchangeRateProvider _provider;

    public CurrencyConverter(IExchangeRateProvider provider)
    {
        _provider = provider;
    }

    public decimal Convert(string from, string to, decimal amount)
    {
        if (!_provider.IsKnownCurrency(from) || !_provider.IsKnownCurrency(to))
            throw new ArgumentException("Currency not supported");

        if (from == to)
            return amount;

        var dkkValue = amount * _provider.GetRateToDKK(from) / 100;
        return dkkValue / (_provider.GetRateToDKK(to) / 100);
    }
}
