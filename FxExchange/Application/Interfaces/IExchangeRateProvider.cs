namespace FxExchangeTool.Application.Interfaces
{
    public interface IExchangeRateProvider
    {
        /// <summary>
        /// Checks if the given ISO currency code is known.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="isoCode">The ISO currency code to check.</param>
        /// <returns>True if the currency code is known; otherwise, false.</returns>
        bool IsKnownCurrency(string isoCode);

        /// <summary>
        /// Gets the exchange rate to DKK for the given ISO currency code.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="isoCode">The ISO currency code for which to get the rate.</param>
        /// <returns>The exchange rate to DKK.</returns>
        decimal GetRateToDKK(string isoCode);
    }
}
