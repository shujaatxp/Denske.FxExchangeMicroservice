using DenskeFxExchange.Interfaces;
using DenskeFxExchange.Services;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: FxExchange <CURRENCY_PAIR> <AMOUNT>");
            return;
        }

        string[] pair = args[0].ToUpper().Split('/');
        if (pair.Length != 2)
        {
            Console.WriteLine("Invalid format. Use FROM/TO e.g., EUR/USD");
            return;
        }

        if (!decimal.TryParse(args[1], out decimal amount))
        {
            Console.WriteLine("Invalid amount.");
            return;
        }

        IExchangeRateProvider provider = new ExchangeRateProvider();
        var converter = new CurrencyConverter(provider);

        try
        {
            var result = converter.Convert(pair[0], pair[1], amount);
            Console.WriteLine($"{amount} {pair[0]} = {result:F4} {pair[1]}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
