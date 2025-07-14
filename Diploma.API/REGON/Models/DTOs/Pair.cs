// Ignore Spelling: REGON, Nazwa
namespace REGON.Models.DTOs
{
    public record Pair
    {
        // Properties 
        public string Symbol { get; init; } = null!;
        public string Nazwa { get; init; } = null!;


        // Methods
        public static Pair? Parse(string? symbol, string? nazwa)
        {
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
