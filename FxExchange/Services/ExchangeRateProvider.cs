using DenskeFxExchange.Interfaces;

namespace DenskeFxExchange.Services;

public class ExchangeRateProvider : IExchangeRateProvider
{
    private readonly Dictionary<string, decimal> _rates = new()
    {
        ["EUR"] = 743.94m,
        ["USD"] = 663.11m,
        ["GBP"] = 852.85m,
        ["SEK"] = 76.10m,
        ["NOK"] = 78.40m,
        ["CHF"] = 683.58m,
        ["JPY"] = 5.9740m,
        ["DKK"] = 100m
    };

    public bool IsKnownCurrency(string iso) => _rates.ContainsKey(iso);

    public decimal GetRateToDKK(string iso)
    {
        if (!_rates.ContainsKey(iso))
            throw new ArgumentException($"Unknown currency: {iso}");
        return _rates[iso];
    }
}
