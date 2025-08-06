using System;
using FxExchangeTool.Application.Interfaces;
using FxExchangeTool.Application.Services;
using FxExchangeTool.Domain.Exceptions;
using FxExchangeTool.Infrastructure;
using Xunit;

namespace FxExchangeTool.Tests
{
    public class CurrencyConversionServiceTests
    {
        private readonly CurrencyConversionService _conversionService;

        public CurrencyConversionServiceTests()
        {
            IExchangeRateProvider provider = new ExchangeRateProvider();
            _conversionService = new CurrencyConversionService(provider);
        }

        #region Converts_EUR_To_USD_Correctly
        // Created by Syed Shujaat Ali
        // Tests conversion from EUR to USD and expects a positive result.
        [Fact]
        public void Converts_EUR_To_USD_Correctly()
        {
            // Act
            var result = _conversionService.Convert("EUR", "USD", 100);

            // Assert
            Assert.True(result > 0, "Conversion result should be greater than zero.");
        }
        #endregion

        #region Returns_Same_For_Same_Currency
        // Created by Syed Shujaat Ali
        // Tests that converting a currency to itself returns the original amount.
        [Fact]
        public void Returns_Same_For_Same_Currency()
        {
            // Act
            var result = _conversionService.Convert("GBP", "GBP", 99);

            // Assert
            Assert.Equal(99m, result);
        }
        #endregion

        #region Throws_For_Unknown_Currency_From
        // Created by Syed Shujaat Ali
        // Tests that an unknown source currency throws UnknownCurrencyException.
        [Fact]
        public void Throws_For_Unknown_Currency_From()
        {
            var ex = Assert.Throws<UnknownCurrencyException>(() => _conversionService.Convert("XYZ", "EUR", 10));
            Assert.Contains("Unknown currency", ex.Message);
        }
        #endregion

        #region Throws_For_Unknown_Currency_To
        // Created by Syed Shujaat Ali
        // Tests that an unknown target currency throws UnknownCurrencyException.
        [Fact]
        public void Throws_For_Unknown_Currency_To()
        {
            var ex = Assert.Throws<UnknownCurrencyException>(() => _conversionService.Convert("EUR", "ABC", 10));
            Assert.Contains("Unknown currency", ex.Message);
        }
        #endregion

        #region Throws_For_Negative_Amount
        // Created by Syed Shujaat Ali
        // Tests that negative amounts throw ArgumentException.
        [Theory]
        [InlineData(-10)]
        [InlineData(-0.01)]
        public void Throws_For_Negative_Amount(decimal amount)
        {
            var ex = Assert.Throws<ArgumentException>(() => _conversionService.Convert("EUR", "USD", amount));
            Assert.Contains("non-negative", ex.Message);
        }
        #endregion

        #region Throws_For_Empty_FromCurrency
        // Created by Syed Shujaat Ali
        // Tests that empty or null source currency codes throw ArgumentException.
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Throws_For_Empty_FromCurrency(string from)
        {
            var ex = Assert.Throws<ArgumentException>(() => _conversionService.Convert(from, "USD", 10));
            Assert.Contains("Currency codes must be non-empty", ex.Message);
        }
        #endregion

        #region Throws_For_Empty_ToCurrency
        // Created by Syed Shujaat Ali
        // Tests that empty or null target currency codes throw ArgumentException.
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Throws_For_Empty_ToCurrency(string to)
        {
            var ex = Assert.Throws<ArgumentException>(() => _conversionService.Convert("EUR", to, 10));
            Assert.Contains("Currency codes must be non-empty", ex.Message);
        }
        #endregion
    }
}
