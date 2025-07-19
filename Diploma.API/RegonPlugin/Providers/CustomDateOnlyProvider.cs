// Ignore Spelling: Regon, Plugin
using System.Globalization;

namespace RegonPlugin.Providers
{
    internal static class CustomDateOnlyProvider
    {
        internal static DateOnly ParseNotNull(string value)
        {
            return DateOnly.Parse(value, CultureInfo.InvariantCulture);
        }

        internal static DateOnly? Parse(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return ParseNotNull(value);
        }
    }
}
