// Ignore Spelling: Regon, Plugin, Nazwa
using RegonPlugin.Providers;

namespace RegonPlugin.Models.DTOs
{
    public record Pair
    {
        public string Symbol { get; init; } = null!;
        public string Nazwa { get; init; } = null!;


        public static Pair? Parse(string? symbol, string? nazwa)
        {
            symbol = CustomStringProvider.AdaptString(symbol);
            nazwa = CustomStringProvider.AdaptString(nazwa);

            if (string.IsNullOrWhiteSpace(symbol) ||
                string.IsNullOrWhiteSpace(nazwa))
            {
                return null;
            }

            return new Pair
            {
                Symbol = symbol,
                Nazwa = nazwa,
            };
        }
    }
}
