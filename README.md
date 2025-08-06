# DenskeFxExchange

A simple .NET 9 console application for converting between major currencies using fixed exchange rates to Danish Krone (DKK).

## Features

- Convert between EUR, USD, GBP, SEK, NOK, CHF, JPY, and DKK.
- Command-line interface for quick conversions.
- Extensible exchange rate provider interface.
- Unit tests for core conversion logic.

## Usage

Build and run the application from the command line:

**Example:**
dotnet run --project DenskeFxExchange --amount 100 --from USD --to EUR

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

- `Program.cs` - Entry point and CLI handling.
- `Models/Currency.cs` - Currency model.
- `Interface/IExchangeRateProvider.cs` - Exchange rate provider interface.
- `Services/ExchangeRateProvider.cs` - Default implementation with hardcoded rates.
- `Services/CurrencyConverter.cs` - Conversion logic.
- `FxExchange.Tests/DenskeFxExchange.Test.cs` - Unit tests using xUnit.

## Running Tests

Run the tests using the .NET CLI: