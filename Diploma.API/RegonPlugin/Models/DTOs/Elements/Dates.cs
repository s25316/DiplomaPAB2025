// Ignore Spelling: Regon, Plugin 
// Ignore Spelling: Powstania, Rozpoczecia, Wpisu, Zawieszenia, Wznowienia, Zmiany, 
// Ignore Spelling: Zakonczenia, Skreslenia, Rejestru, Ewidencji 
using Provider = RegonPlugin.Providers.CustomDateOnlyProvider;
using RaportJednostkiResponse = RegonPlugin.Responses.Raporty.Jednostki.RaportJednostki;

namespace RegonPlugin.Models.DTOs.Elements
{
    public record Dates
    {
        public DateOnly DataPowstania { get; init; }
        public DateOnly DataRozpoczecia { get; init; }
        public DateOnly? DataWpisu { get; init; }
        public DateOnly? DataZawieszenia { get; init; } = null;
        public DateOnly? DataWznowienia { get; init; } = null;
        public DateOnly? DataZmiany { get; init; } = null;
        public DateOnly? DataZakonczenia { get; init; } = null;
        public DateOnly? DataSkreslenia { get; init; } = null;
        public DateOnly? DataWpisuDoRejestruEwidencji { get; init; } = null;


        public static implicit operator Dates(RaportJednostkiResponse response) => Parse(response);
        public static Dates Parse(RaportJednostkiResponse response)
        {
            return new Dates
            {
                DataPowstania = Provider.ParseNotNull(response.DataPowstania),
                DataRozpoczecia = Provider.ParseNotNull(response.DataRozpoczecia),
                DataWpisu = Provider.Parse(response.DataWpisu),
                DataZawieszenia = Provider.Parse(response.DataZawieszenia),
                DataWznowienia = Provider.Parse(response.DataWznowienia),
                DataZmiany = Provider.Parse(response.DataZmiany),
                DataZakonczenia = Provider.Parse(response.DataZakonczenia),
                DataSkreslenia = Provider.Parse(response.DataSkreslenia),
                DataWpisuDoRejestruEwidencji = Provider.Parse(response.DataWpisuDoRejestruEwidencji),
            };
        }
    }
}
