// Ignore Spelling: Teryt, Plugin, Simc, Terc,  Wojewodstwo, Powiat, Gmina, Rodzaj, Nazwa
// Ignore Spelling:  Miejscowosc, Ulica, Ulic
using System.Globalization;
using TerytPlugin.Models;

namespace TerytPlugin.FileModels
{
    public class UlicInfo
    {
        public string WojewodstwoId { get; init; } = null!;
        public string PowiatId { get; init; } = null!;
        public string GminaId { get; init; } = null!;
        public GminaType? GminaRodzaj { get; init; } = null!;
        public string MiejscowoscId { get; init; } = null!;
        public string UlicaId { get; init; } = null!;
        public string? Type { get; init; } = null;
        public string Nazwa1 { get; init; } = null!;
        public string? Nazwa2 { get; init; } = null!;
        public DateOnly Date { get; init; }


        public static implicit operator UlicInfo(string value)
        {
            var items = value.Split(';');
            if (items.Length != 10)
            {
                throw new NotImplementedException();
            }

            return new UlicInfo
            {
                WojewodstwoId = items[0].Trim(),
                PowiatId = items[1].Trim(),
                GminaId = items[2].Trim(),
                GminaRodzaj = items[3],
                MiejscowoscId = items[4].Trim(),
                UlicaId = items[5].Trim(),
                Type = Adapt(items[6].Trim()),
                Nazwa1 = items[7].Trim(),
                Nazwa2 = Adapt(items[8]),
                Date = DateOnly.Parse(items[9], CultureInfo.InvariantCulture),
            };
        }

        public Street GetStreet()
        {
            var nazwa = string.Empty;
            if (!string.IsNullOrWhiteSpace(Nazwa2))
            {
                nazwa = $"{Nazwa2} {Nazwa1}";
            }
            else
            {
                nazwa = Nazwa1;
            }

            return new Street
            {
                Id = UlicaId,
                Name = nazwa,
                Type = Type,
            };
        }

        public Connection GetConnection()
        {
            return new Connection(MiejscowoscId, UlicaId);
        }

        private static string? Adapt(string? value)
        {
            return !string.IsNullOrWhiteSpace(value)
                    ? value.Trim()
                    : null;
        }
    }
}
