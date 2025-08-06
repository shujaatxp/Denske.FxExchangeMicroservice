using FxExchangeTool.Application.Interfaces;
using FxExchangeTool.Domain.Exceptions;
using System.Collections.Generic;

namespace FxExchangeTool.Infrastructure
{
    public class ExchangeRateProvider : IExchangeRateProvider
    {
        private readonly Dictionary<string, decimal> _rates = new()
        {
            { "EUR", 743.94m },
            { "USD", 663.11m },
            { "GBP", 852.85m },     
            { "SEK", 76.10m },
            { "NOK", 78.40m },
            { "CHF", 683.58m },
            { "JPY", 5.9740m },
            { "DKK", 100m } // Base value
        };

        /// <summary>
        /// Checks if the given ISO currency code is known.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="isoCode">The ISO currency code to check.</param>
        /// <returns>True if the currency code is known; otherwise, false.</returns>
        public bool IsKnownCurrency(string isoCode) => _rates.ContainsKey(isoCode);

        /// <summary>
        /// Gets the exchange rate to DKK for the given ISO currency code.
        /// Throws UnknownCurrencyException if the currency is not known.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="isoCode">The ISO currency code for which to get the rate.</param>
        /// <returns>The exchange rate to DKK.</returns>
        /// <exception cref="UnknownCurrencyException">Thrown if the currency code is not known.</exception>
        public decimal GetRateToDKK(string isoCode)
        {
            if (!_rates.ContainsKey(isoCode))
                throw new UnknownCurrencyException(isoCode);

            return _rates[isoCode];
        }
    }
}
