// Ignore Spelling: Teryt, Plugin, Simc, Terc,  Wojewodstwo, Powiat, Gmina, Rodzaj, Nazwa
// Ignore Spelling: Zwyczajowa, Miejscowosc
using System.Globalization;

namespace TerytPlugin.FileModels
{
    public class SimcInfo
    {
        public string WojewodstwoId { get; init; } = null!;
        public string PowiatId { get; init; } = null!;
        public string GminaId { get; init; } = null!;
        public GminaType? GminaRodzaj { get; init; } = null!;
        public MiejscowoscType MiejscowoscRodzaj { get; init; } = null!;
        public bool HasNazwaZwyczajowa { get; init; }
        public string Nazwa { get; init; } = null!;
        public string MiejscowoscId { get; init; } = null!;
        public string? ParentId { get; init; } = null!;
        public DateOnly Date { get; init; }


        public static implicit operator SimcInfo(string value)
        {
            var items = value.Split(';');
            if (items.Length != 10)
            {
                throw new NotImplementedException();
            }

            return new SimcInfo
            {
                WojewodstwoId = items[0].Trim(),
                PowiatId = items[1].Trim(),
                GminaId = items[2].Trim(),
                GminaRodzaj = items[3].Trim(),
                MiejscowoscRodzaj = items[4].Trim(),
                HasNazwaZwyczajowa = int.Parse(items[5].Trim()) > 0,
                Nazwa = items[6].Trim(),
                MiejscowoscId = items[7].Trim(),
                ParentId = CheckDuplicate(items[7], items[8]),
                Date = DateOnly.Parse(items[9].Trim(), CultureInfo.InvariantCulture),
            };
        }

        private static string? CheckDuplicate(string value1, string value2)
        {
            value1 = value1.Trim();
            value2 = value2.Trim();
            if (value1 == value2)
            {
                return null;
            }
            return value2;
        }
    }
}
