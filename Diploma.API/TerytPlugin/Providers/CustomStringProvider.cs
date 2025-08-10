// Ignore Spelling: Teryt, Plugin
namespace TerytPlugin.Providers
{
    internal class CustomStringProvider
    {
        public static string? Adapt(string? value)
        {
            return !string.IsNullOrWhiteSpace(value)
                    ? value.Trim()
                    : null;
        }

        public static string DivisionIdGenerator(params string[] values)
        {
            return string.Join(" ", values);
        }

    }
}
