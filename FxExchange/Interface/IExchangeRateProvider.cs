namespace DenskeFxExchange.Interfaces;

public interface IExchangeRateProvider
{
    bool IsKnownCurrency(string iso);
    decimal GetRateToDKK(string iso);
}
