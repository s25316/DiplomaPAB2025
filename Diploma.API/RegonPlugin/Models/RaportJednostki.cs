// Ignore spelling: Regon, Plugin, Raport, Jednostki
// Ignore spelling: Nazwa, Skrocona, Adres, Kontakty, Daty, Numerw, Rejestrze, Ewidencji
// Ignore spelling: Rejestrowy, Rodzaj, Rejestru, Forma, Finansowania, Podstawowa, Prawna
// Ignore spelling: Szczegolna, Zalozycielski, Wlasnosci, Dzialalnosci
using RegonPlugin.Models.DTOs;
using RegonPlugin.Providers;
using System.Text.RegularExpressions;
using RaportJednostkiResponse = RegonPlugin.Responses.Raporty.Jednostki.RaportJednostki;

namespace RegonPlugin.Models
{
    public record RaportJednostki
    {
        public string Regon { get; init; } = null!;
        public string? Nip { get; init; } = null;
        public string Nazwa { get; init; } = null!;
        public string? NazwaSkrocona { get; init; } = null;
        public string? NumerwRejestrzeEwidencji { get; init; } = null;
        public string? Dzialalnosci { get; init; } = null;
        public Address? Adres { get; init; } = null;
        public Contacts? Kontakty { get; init; } = null;
        public Dates Daty { get; init; } = null!;
        public Pair? OrganRejestrowy { get; init; } = null;
        public Pair? RodzajRejestru { get; init; } = null;
        public Pair? FormaFinansowania { get; init; } = null;
        public Pair? PodstawowaFormaPrawna { get; init; } = null;
        public Pair? SzczegolnaFormaPrawna { get; init; } = null;
        public Pair? OrganZalozycielski { get; init; } = null;
        public Pair? FormaWlasnosci { get; init; } = null;
        public Pair? Silos { get; init; } = null;


        public static implicit operator RaportJednostki(RaportJednostkiResponse response) => Parse(response);
        public static RaportJednostki Parse(RaportJednostkiResponse response)
        {
            var regon = Regex.Replace(
                response.Regon,
                ConfigureData.REGEX_REGON_REPLACE_ZEROS,
                "$1");

            return new RaportJednostki
            {
                Regon = regon,
                Nazwa = response.Nazwa,
                Nip = CustomStringProvider.AdaptString(response.Nip),
                NazwaSkrocona = CustomStringProvider.AdaptString(response.NazwaSkrocona),
                NumerwRejestrzeEwidencji = CustomStringProvider.AdaptString(response.NumerwRejestrzeEwidencji),
                Dzialalnosci = CustomStringProvider.AdaptString(response.Dzialalnosci),
                Adres = response,
                Kontakty = response,
                Daty = response,
                OrganRejestrowy = Pair.Parse(
                    response.OrganRejestrowySymbol,
                    response.OrganRejestrowyNazwa),
                RodzajRejestru = Pair.Parse(
                    response.RodzajRejestruSymbol,
                    response.RodzajRejestruNazwa),
                FormaFinansowania = Pair.Parse(
                    response.FormaFinansowaniaSymbol,
                    response.FormaFinansowaniaNazwa),
                PodstawowaFormaPrawna = Pair.Parse(
                    response.PodstawowaFormaPrawnaSymbol,
                    response.PodstawowaFormaPrawnaNazwa),
                SzczegolnaFormaPrawna = Pair.Parse(
                    response.SzczegolnaFormaPrawnaSymbol,
                    response.SzczegolnaFormaPrawnaNazwa),
                OrganZalozycielski = Pair.Parse(
                    response.OrganZalozycielskiSymbol,
                    response.OrganZalozycielskiNazwa),
                FormaWlasnosci = Pair.Parse(
                    response.FormaWlasnosciSymbol,
                    response.FormaWlasnosciNazwa),
                Silos = Pair.Parse(
                    response.SilosSymbol,
                    response.SilosNazwa),
            };
        }
    }
}
