// Ignore Spelling: REGON
// Ignore Spelling: Kraj, Wojewodztwo, Powiat, Gmina, Miejscowosc, Poczty
// Ignore Spelling: Ulica, Kod, Pocztowy, Numer, Nieruchomosci, Lokalu, Nietypowe, Miejsce, Lokalizacji
using REGON.Responses.FullData;

namespace REGON.Models.DTOs
{
    public class Address
    {
        // Properties
        public Pair Kraj { get; init; } = null!;
        public Pair Wojewodztwo { get; init; } = null!;
        public Pair Powiat { get; init; } = null!;
        public Pair Gmina { get; init; } = null!;
        public Pair MiejscowoscPoczty { get; init; } = null!;
        public Pair Miejscowosc { get; init; } = null!;
        public Pair? Ulica { get; init; } = null;
        public string KodPocztowy { get; init; } = null!;
        public string NumerNieruchomosci { get; init; } = null!;
        public string? NumerLokalu { get; init; } = null;
        public string? NietypoweMiejsceLokalizacji { get; init; } = null;


        // Methods
        public static Address? Parse(FullDataResponse response)
        {
            var kraj = Pair.Parse(response.KrajSymbol, response.KrajNazwa);
            var wojewodztwo = Pair.Parse(response.WojewodztwoSymbol, response.WojewodztwoNazwa);
            var powiat = Pair.Parse(response.PowiatSymbol, response.PowiatNazwa);
            var gmina = Pair.Parse(response.GminaSymbol, response.GminaNazwa);
            var miejscowoscPoczty = Pair.Parse(response.MiejscowoscPocztySymbol, response.MiejscowoscPocztyNazwa);
            var miejscowosc = Pair.Parse(response.MiejscowoscSymbol, response.MiejscowoscNazwa);
            var ulica = Pair.Parse(response.UlicaSymbol, response.UlicaNazwa);

            if (kraj is null ||
                wojewodztwo is null ||
                powiat is null ||
                gmina is null ||
                miejscowoscPoczty is null ||
                miejscowosc is null ||
                string.IsNullOrWhiteSpace(response.KodPocztowy) ||
                string.IsNullOrWhiteSpace(response.NumerNieruchomosci))
            {
                return null;
            }

            return new Address
            {
                Kraj = kraj,
                Wojewodztwo = wojewodztwo,
                Powiat = powiat,
                Gmina = gmina,
                MiejscowoscPoczty = miejscowoscPoczty,
                Miejscowosc = miejscowosc,
                Ulica = ulica,
                KodPocztowy = response.KodPocztowy,
                NumerNieruchomosci = response.NumerNieruchomosci,
                NumerLokalu = ParseString(response.NumerLokalu),
                NietypoweMiejsceLokalizacji = ParseString(response.NietypoweMiejsceLokalizacji),
            };
        }

        private static string? ParseString(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return value.Trim();
        }
    }
}
