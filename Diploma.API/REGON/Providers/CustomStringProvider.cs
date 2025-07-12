// Ignore Spelling: Regon
using System.Text.RegularExpressions;

namespace REGON.Providers
{
    internal static class CustomStringProvider
    {
        internal static string ExtractDigits(string value)
        {
            return Regex.Replace(value, @"\D", "");
        }
    }
}
