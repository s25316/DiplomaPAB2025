// Ignore Spelling: REGON, Nazwa, Skrocona, Numer, Adres, Kontakty, Daty, Rejestru, Ewidencji 
// Ignore Spelling: Numerw, Rejestrze, Rejestrowy, Rodzaj, Forma, Finansowania
// Ignore Spelling: Podstawowa, Prawna, Szczegolna, Zalozycielski, Wlasnosci
using REGON.Models.DTOs;
using REGON.Responses.FullData;
using System.Text.RegularExpressions;

namespace REGON.Models
{
    public record FullReport
    {
        // Fields
        private static readonly string _pattern = @"^(\d{9})(0{5})$";
        // Properties
        public string Regon { get; init; } = null!;
        public string Nazwa { get; init; } = null!;
        public string? Nip { get; init; } = null;
        public string? NazwaSkrocona { get; init; } = null;
        public Address? Adres { get; init; } = null;
        public Contacts? Kontakty { get; init; } = null;
        public Dates Daty { get; init; } = null!;
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
            // Sometimes Returns REGON with 5 zeros, and this removes
            var regon = Regex.Replace(res.Regon, _pattern, "$1");

            return new FullReport
            {
                Regon = regon,
                Nazwa = res.Nazwa,
                Nip = ParseString(res.Nip),
                NazwaSkrocona = ParseString(res.NazwaSkrocona),
                Adres = Address.Parse(res),
                Kontakty = Contacts.Parse(res),
                Daty = Dates.Parse(res),
                NumerwRejestrzeEwidencji = ParseString(res.NumerwRejestrzeEwidencji),
                OrganRejestrowy = Pair.Parse(
                    res.OrganRejestrowySymbol,
                    res.OrganRejestrowyNazwa),
                RodzajRejestru = Pair.Parse(
                    res.RodzajRejestruSymbol,
                    res.RodzajRejestruNazwa),
                FormaFinansowania = Pair.Parse(
                    res.FormaFinansowaniaSymbol,
                    res.FormaFinansowaniaNazwa),
                PodstawowaFormaPrawna = Pair.Parse(
                    res.PodstawowaFormaPrawnaSymbol,
                    res.PodstawowaFormaPrawnaNazwa),
                SzczegolnaFormaPrawna = Pair.Parse(
                    res.SzczegolnaFormaPrawnaSymbol,
                    res.SzczegolnaFormaPrawnaNazwa),
                OrganZalozycielski = Pair.Parse(
                    res.OrganZalozycielskiSymbol,
                    res.OrganZalozycielskiNazwa),
                FormaWlasnosci = Pair.Parse(
                    res.FormaWlasnosciSymbol,
                    res.FormaWlasnosciNazwa),
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
