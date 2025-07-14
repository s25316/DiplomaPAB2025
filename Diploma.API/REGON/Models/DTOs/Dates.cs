// Ignore Spelling: REGON, Powstania, Rozpoczecia, Wpisu
// Ignore Spelling: Zawieszenia, Wznowienia, Zmiany, Zakonczenia, Skreslenia, Rejestru, Ewidencji
using REGON.Responses.FullData;
using System.Globalization;

namespace REGON.Models.DTOs
{
    public class Dates
    {
        // Properties
        public DateOnly DataPowstania { get; init; }
        public DateOnly DataRozpoczecia { get; init; }
        public DateOnly? DataWpisu { get; init; }
        public DateOnly? DataZawieszenia { get; init; } = null;
        public DateOnly? DataWznowienia { get; init; } = null;
        public DateOnly? DataZmiany { get; init; } = null;
        public DateOnly? DataZakonczenia { get; init; } = null;
        public DateOnly? DataSkreslenia { get; init; } = null;
        public DateOnly? DataWpisuDoRejestruEwidencji { get; init; } = null;


        // Methods
        public static Dates Parse(FullDataResponse response)
        {
            return new Dates
            {
                DataPowstania = DateOnly.Parse(response.DataPowstania, CultureInfo.InvariantCulture),
                DataRozpoczecia = DateOnly.Parse(response.DataRozpoczecia, CultureInfo.InvariantCulture),
                DataWpisu = ParseDateOnly(response.DataWpisu),
                DataZawieszenia = ParseDateOnly(response.DataZawieszenia),
                DataWznowienia = ParseDateOnly(response.DataWznowienia),
                DataZmiany = ParseDateOnly(response.DataZmiany),
                DataZakonczenia = ParseDateOnly(response.DataZakonczenia),
                DataSkreslenia = ParseDateOnly(response.DataSkreslenia),
                DataWpisuDoRejestruEwidencji = ParseDateOnly(response.DataWpisuDoRejestruEwidencji),
            };
        }

        private static DateOnly? ParseDateOnly(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            return DateOnly.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}
