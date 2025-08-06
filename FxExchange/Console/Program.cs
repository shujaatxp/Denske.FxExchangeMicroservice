using FxExchangeTool.Application.Services;
using FxExchangeTool.Infrastructure;
using FxExchangeTool.Domain.Exceptions;
using System;

namespace FxExchangeTool.UI
{
    /// <summary>
    /// Entry point for the FX Exchange console application.
    /// Created by Syed Shujaat Ali.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method to run the console application.
        /// Created by Syed Shujaat Ali.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: FxExchangeTool <CURRENCY_PAIR> <AMOUNT>");
                Console.WriteLine("Example: FxExchangeTool EUR/USD 10");
                return;
            }

            try
            {
                string[] currencies = args[0].Split('/');
                if (currencies.Length != 2)
                {
                    Console.WriteLine("Invalid currency pair format. Use format FROM/TO, e.g., EUR/USD");
                    return;
                }

                string from = currencies[0].ToUpper();
                string to = currencies[1].ToUpper();

                if (!decimal.TryParse(args[1], out decimal amount) || amount < 0)
                {
                    Console.WriteLine("Invalid amount. Please enter a non-negative number.");
                    return;
                }

                var rateProvider = new ExchangeRateProvider();
                var conversionService = new CurrencyConversionService(rateProvider);

                decimal result = conversionService.Convert(from, to, amount);
                Console.WriteLine($"{amount} {from} = {result:F4} {to}");
            }
            catch (UnknownCurrencyException uce)
            {
                Console.WriteLine($"Error: {uce.Message}");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine($"Error: {ae.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
