// Ignore Spelling: Teryt, Plugin, Terc,  Wojewodstwo, Powiat, Gmina, Rodzaj, Nazwa
using System.Globalization;

namespace TerytPlugin.FileModels
{
    public record TercInfo
    {
        public string WojewodstwoId { get; init; } = null!;
        public string? PowiatId { get; init; }
        public string? GminaId { get; init; } = null!;
        public GminaType? Type { get; init; } = null!;
        public string Nazwa1 { get; init; } = null!;
        public string TypeName { get; init; } = null!;
        public DateOnly Date { get; init; }


        public static implicit operator TercInfo(string value)
        {
            var items = value.Split(';');
            if (items.Count() != 7)
            {
                throw new NotImplementedException();
            }

            return new TercInfo
            {
                WojewodstwoId = items[0].Trim(),
                PowiatId = Adapt(items[1]),
                GminaId = Adapt(items[2]),
                Type = items[3].Trim(),
                Nazwa1 = items[4].Trim(),
                TypeName = Adapt(items[5]) ?? throw new ArgumentException(items[5]),
                Date = DateOnly.Parse(items[6], CultureInfo.InvariantCulture)
            };
        }

        private static string? Adapt(string? value)
        {
            return !string.IsNullOrWhiteSpace(value)
                    ? value.Trim()
                    : null;
        }
    }
}
