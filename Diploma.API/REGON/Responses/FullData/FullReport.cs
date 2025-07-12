// Ignore Spelling: REGON, Nazwa, Skrocona, Kraj, Wojewodztwo, Powiat, Gmina, Miejscowosc, Poczty
// Ignore Spelling: Ulica, Kod, Pocztowy, Numer, Nieruchomosci, Lokalu, Nietypowe, Miejsce, Lokalizacji
// Ignore Spelling: Telefonu, Wewnetrzny, Faksu, Adres, Powstania, Rozpoczecia, Wpisu
// Ignore Spelling: Zawieszenia, Wznowienia, Zmiany, Zakonczenia, Skreslenia, Rejestru, Ewidencji 
// Ignore Spelling: Numerw, Rejestrze, Rejestrowy, Rodzaj, Forma, Finansowania
// Ignore Spelling: Podstawowa, Prawna, Szczegolna, Zalozycielski, Wlasnosci
using REGON.Responses.FullData.Models;

namespace REGON.Responses.FullData
{
    public record FullReport
    {
        public string Regon { get; init; } = null!;
        public string Nazwa { get; init; } = null!;
        public string? Nip { get; init; } = null;
        public string? NazwaSkrocona { get; init; } = null;
        public Pair? Kraj { get; init; } = null;
        public Pair? Wojewodztwo { get; init; } = null;
        public Pair? Powiat { get; init; } = null;
        public Pair? Gmina { get; init; } = null;
        public Pair? MiejscowoscPoczty { get; init; } = null;
        public Pair? Miejscowosc { get; init; } = null;
        public Pair? Ulica { get; init; } = null;
        public string? KodPocztowy { get; init; } = null;
        public string? NumerNieruchomosci { get; init; } = null;
        public string? NumerLokalu { get; init; } = null;
        public string? NietypoweMiejsceLokalizacji { get; init; } = null;
        public IEnumerable<string> NumerTelefonu { get; init; } = [];
        public IEnumerable<string> NumerWewnetrznyTelefonu { get; init; } = [];
        public IEnumerable<string> NumerFaksu { get; init; } = [];
        public IEnumerable<string> AdresEmail { get; init; } = [];
        public IEnumerable<string> WWW { get; init; } = [];
        public DateOnly DataPowstania { get; init; }
        public DateOnly DataRozpoczecia { get; init; }
        public DateOnly? DataWpisu { get; init; }
        public DateOnly? DataZawieszenia { get; init; } = null;
        public DateOnly? DataWznowienia { get; init; } = null;
        public DateOnly? DataZmiany { get; init; } = null;
        public DateOnly? DataZakonczenia { get; init; } = null;
        public DateOnly? DataSkreslenia { get; init; } = null;
        public DateOnly? DataWpisuDoRejestruEwidencji { get; init; } = null;
        public string? NumerwRejestrzeEwidencji { get; init; } = null;
        public Pair? OrganRejestrowy { get; init; } = null;
        public Pair? RodzajRejestru { get; init; } = null;
        public Pair? FormaFinansowania { get; init; } = null;
        public Pair? PodstawowaFormaPrawna { get; init; } = null;
        public Pair? SzczegolnaFormaPrawna { get; init; } = null;
        public Pair? OrganZalozycielski { get; init; } = null;
        public Pair? FormaWlasnosci { get; init; } = null;


        // Methods
        public static implicit operator FullReport(FullDataResponse res)
        {
            return new FullReport
            {
                Regon = res.Regon,
                Nazwa = res.Nazwa,
                Nip = ParseString(res.Nip),
                NazwaSkrocona = ParseString(res.NazwaSkrocona),
                Kraj = ParseToPair(
                    res.KrajSymbol,
                    res.KrajNazwa),
                Wojewodztwo = ParseToPair(
                    res.WojewodztwoSymbol,
                    res.WojewodztwoNazwa),
                Powiat = ParseToPair(
                    res.PowiatSymbol,
                    res.PowiatNazwa),
                Gmina = ParseToPair(
                    res.GminaSymbol,
                    res.GminaNazwa),
                MiejscowoscPoczty = ParseToPair(
                    res.MiejscowoscPocztySymbol,
                    res.MiejscowoscPocztyNazwa),
                Miejscowosc = ParseToPair(
                    res.MiejscowoscSymbol,
                    res.MiejscowoscNazwa),
                Ulica = ParseToPair(
                    res.UlicaSymbol,
                    res.UlicaNazwa),
                KodPocztowy = ParseString(res.KodPocztowy),
                NumerNieruchomosci = ParseString(res.NumerNieruchomosci),
                NumerLokalu = ParseString(res.NumerLokalu),
                NietypoweMiejsceLokalizacji = ParseString(res.NietypoweMiejsceLokalizacji),
                NumerTelefonu = res
                    .NumerTelefonu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                NumerWewnetrznyTelefonu = res
                    .NumerWewnetrznyTelefonu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                NumerFaksu = res
                    .NumerFaksu
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                AdresEmail = res
                    .AdresEmail
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                WWW = res
                    .WWW
                    .Where(item => !string.IsNullOrWhiteSpace(item)),
                DataPowstania = DateOnly.Parse(res.DataPowstania),
                DataRozpoczecia = DateOnly.Parse(res.DataRozpoczecia),
                DataWpisu = ParseDateOnly(res.DataWpisu),
                DataZawieszenia = ParseDateOnly(res.DataZawieszenia),
                DataWznowienia = ParseDateOnly(res.DataWznowienia),
                DataZmiany = ParseDateOnly(res.DataZmiany),
                DataZakonczenia = ParseDateOnly(res.DataZakonczenia),
                DataSkreslenia = ParseDateOnly(res.DataSkreslenia),
                DataWpisuDoRejestruEwidencji = ParseDateOnly(res.DataWpisuDoRejestruEwidencji),
                NumerwRejestrzeEwidencji = ParseString(res.NumerwRejestrzeEwidencji),
                OrganRejestrowy = ParseToPair(
                    res.OrganRejestrowySymbol,
                    res.OrganRejestrowyNazwa),
                RodzajRejestru = ParseToPair(
                    res.RodzajRejestruSymbol,
                    res.RodzajRejestruNazwa),
                FormaFinansowania = ParseToPair(
                    res.FormaFinansowaniaSymbol,
                    res.FormaFinansowaniaNazwa),
                PodstawowaFormaPrawna = ParseToPair(
                    res.PodstawowaFormaPrawnaSymbol,
                    res.PodstawowaFormaPrawnaNazwa),
                SzczegolnaFormaPrawna = ParseToPair(
                    res.SzczegolnaFormaPrawnaSymbol,
                    res.SzczegolnaFormaPrawnaNazwa),
                OrganZalozycielski = ParseToPair(
                    res.OrganZalozycielskiSymbol,
                    res.OrganZalozycielskiNazwa),
                FormaWlasnosci = ParseToPair(
                    res.FormaWlasnosciSymbol,
                    res.FormaWlasnosciNazwa),
            };
        }

        private static Pair? ParseToPair(string? symbol, string? nazwa)
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

        private static DateOnly? ParseDateOnly(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return DateOnly.Parse(value);
        }

        private static string? ParseString(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return value;
        }
    }
}
