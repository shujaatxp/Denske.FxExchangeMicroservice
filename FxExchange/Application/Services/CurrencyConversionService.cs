using FxExchangeTool.Application.Interfaces;
using FxExchangeTool.Domain.Exceptions;
using System;

namespace FxExchangeTool.Application.Services
{
    public class CurrencyConversionService
    {
        private readonly IExchangeRateProvider _rateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyConversionService"/> class.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="rateProvider">The exchange rate provider to use for conversions.</param>
        public CurrencyConversionService(IExchangeRateProvider rateProvider)
        {
            _rateProvider = rateProvider;
        }

        /// <summary>
        /// Converts an amount from one currency to another.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="fromCurrency">The ISO code of the source currency.</param>
        /// <param name="toCurrency">The ISO code of the target currency.</param>
        /// <param name="amount">The amount to convert.</param>
        /// <returns>The converted amount.</returns>
        /// <exception cref="ArgumentException">Thrown if currency codes are invalid or amount is negative.</exception>
        /// <exception cref="UnknownCurrencyException">Thrown if a currency code is unknown.</exception>
        public decimal Convert(string fromCurrency, string toCurrency, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(fromCurrency) || string.IsNullOrWhiteSpace(toCurrency))
                throw new ArgumentException("Currency codes must be non-empty.");

            if (!_rateProvider.IsKnownCurrency(fromCurrency))
                throw new UnknownCurrencyException(fromCurrency);

            if (!_rateProvider.IsKnownCurrency(toCurrency))
                throw new UnknownCurrencyException(toCurrency);

            if (amount < 0)
                throw new ArgumentException("Amount must be non-negative.");

            if (fromCurrency == toCurrency)
                return Math.Round(amount, 4);

            return Math.Round(ConvertViaDKK(fromCurrency, toCurrency, amount), 4);
        }

        /// <summary>
        /// Converts an amount from one currency to another via DKK as the base currency.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="fromCurrency">The ISO code of the source currency.</param>
        /// <param name="toCurrency">The ISO code of the target currency.</param>
        /// <param name="amount">The amount to convert.</param>
        /// <returns>The converted amount.</returns>
        private decimal ConvertViaDKK(string fromCurrency, string toCurrency, decimal amount)
        {
            decimal fromRate = _rateProvider.GetRateToDKK(fromCurrency);
            decimal toRate = _rateProvider.GetRateToDKK(toCurrency);

            decimal dkkAmount = amount * fromRate / 100m;
            decimal result = dkkAmount / (toRate / 100m);
            return result;
        }
    }
}
