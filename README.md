# DenskeFxExchange

A simple .NET 9 console application for converting between major currencies using fixed exchange rates to Danish Krone (DKK).

## Features

- Convert between EUR, USD, GBP, SEK, NOK, CHF, JPY, and DKK.
- Command-line interface for quick conversions.
- Extensible exchange rate provider interface.
- Robust error handling for invalid input and unknown currencies.
- Unit tests for core conversion logic.

## Usage

Build and run the application from the command line:

The application will prompt for:
- Source currency code (e.g., USD)
- Target currency code (e.g., EUR)
- Amount to convert

**Example:**
dotnet run --project DenskeFxExchange --amount 100 --from USD --to EUR

**Example session:**

## Supported Currencies

- EUR (Euro)
- USD (US Dollar)
- GBP (British Pound)
- SEK (Swedish Krona)
- NOK (Norwegian Krone)
- CHF (Swiss Franc)
- JPY (Japanese Yen)
- DKK (Danish Krone)

## Error Handling

- Invalid currency codes or unsupported pairs will result in an error message.
- If the source and target currencies are the same, the original amount is returned.

## Project Structure

- `FxExchange\Console\Program.cs` - Entry point and CLI handling.
- `FxExchange\Domain\Entites\Currency.cs` - Currency model.
- `FxExchange\Application\Interfaces\IExchangeRateProvider.cs` - Exchange rate provider interface.
- `FxExchange\Infrastructure\ExchangeRateProvider.cs` - Default implementation with hardcoded rates.
- `FxExchange\Application\Services\CurrencyConversionService.cs` - Conversion logic.
- `FxExchange\Domain\Exceptions\UnknownCurrencyException.cs` - Custom exception for unknown currencies.
- `FxExchange.Tests\DenskeFxExchange.Test.cs` - Unit tests using xUnit.

## Running Tests

Run the tests using the .NET CLI:

## Author

---

*This project targets .NET 9 and is intended for educational and demonstration purposes.*