// Ignore Spelling: Regon, Plugin
using System.Text.RegularExpressions;

namespace RegonPlugin.Providers
{
    internal static class CustomStringProvider
    {
        internal static string ExtractDigits(string value)
        {
            return Regex.Replace(value, @"\D", "");
        }

        internal static string DecodeXmlEnvelope(string envelope)
        {
            return envelope
                .Replace("&lt;", "<")
                .Replace("&gt;", ">")
                .Replace("&#xD;", "")
                .Replace("&amp;", "&");
        }

        internal static string? AdaptString(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return value.Trim();
        }
    }
}
