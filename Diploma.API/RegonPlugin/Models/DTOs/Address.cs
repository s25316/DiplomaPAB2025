// Ignore Spelling: Regon, Plugin
// Ignore Spelling: Kraj, Wojewodztwo, Powiat, Gmina, Miejscowosc, Poczty, Ulica, Kod
// Ignore Spelling: Pocztowy, Numer, Nieruchomosci, Lokalu, Nietypowe, Miejsce, Lokalizacji
using RegonPlugin.Providers;
using RaportJednostkiResponse = RegonPlugin.Responses.Raporty.Jednostki.RaportJednostki;

namespace RegonPlugin.Models.DTOs
{
    public record Address
    {
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


        public static implicit operator Address?(RaportJednostkiResponse response) => Parse(response);
        public static Address? Parse(RaportJednostkiResponse response)
        {
            var kraj = Pair.Parse(
                response.KrajSymbol,
                response.KrajNazwa);
            var wojewodztwo = Pair.Parse(
                response.WojewodztwoSymbol,
                response.WojewodztwoNazwa);
            var powiat = Pair.Parse(
                response.PowiatSymbol,
                response.PowiatNazwa);
            var gmina = Pair.Parse(
                response.GminaSymbol,
                response.GminaNazwa);
            var miejscowoscPoczty = Pair.Parse(
                response.MiejscowoscPocztySymbol,
                response.MiejscowoscPocztyNazwa);
            var miejscowosc = Pair.Parse(
                response.MiejscowoscSymbol,
                response.MiejscowoscNazwa);
            var ulica = Pair.Parse(
                response.UlicaSymbol,
                response.UlicaNazwa);
            var kodPocztowy = CustomStringProvider.AdaptString(response.KodPocztowy);
            var numerNieruchomosci = CustomStringProvider.AdaptString(response.NumerNieruchomosci);
            var numerLokalu = CustomStringProvider.AdaptString(response.NumerLokalu);
            var nietypoweMiejsceLokalizacji = CustomStringProvider.AdaptString(response.NietypoweMiejsceLokalizacji);


            if (kraj is null ||
                wojewodztwo is null ||
                powiat is null ||
                gmina is null ||
                miejscowoscPoczty is null ||
                miejscowosc is null ||
                string.IsNullOrWhiteSpace(kodPocztowy) ||
                string.IsNullOrWhiteSpace(numerNieruchomosci))
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
                KodPocztowy = kodPocztowy,
                NumerNieruchomosci = numerNieruchomosci,
                NumerLokalu = numerLokalu,
                NietypoweMiejsceLokalizacji = nietypoweMiejsceLokalizacji,
            };
        }
    }
}
