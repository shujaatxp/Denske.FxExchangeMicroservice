using System;

namespace FxExchangeTool.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when an unknown currency code is encountered.
    /// Created by Syed Shujaat Ali.
    /// </summary>
    public class UnknownCurrencyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownCurrencyException"/> class.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="isoCode">The unknown ISO currency code.</param>
        public UnknownCurrencyException(string isoCode)
            : base($"Unknown currency code: {isoCode}")
        {
        }
    }
}
