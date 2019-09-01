using System.Globalization;

namespace OneTwoOne.Module.Core.Services
{
    public interface ICurrencyService
    {
        CultureInfo CurrencyCulture { get; }

        string FormatCurrency(decimal value);
    }
}
