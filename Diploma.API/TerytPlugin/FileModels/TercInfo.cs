// Ignore Spelling: Teryt, Plugin, Terc,  Wojewodstwo, Powiat, Gmina, Rodzaj, Nazwa
using System.Globalization;
using TerytPlugin.Models;
using TerytPlugin.Providers;

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
                PowiatId = CustomStringProvider.Adapt(items[1]),
                GminaId = CustomStringProvider.Adapt(items[2]),
                Type = items[3].Trim(),
                Nazwa1 = items[4].Trim(),
                TypeName = CustomStringProvider.Adapt(items[5]) ?? throw new ArgumentException(items[5]),
                Date = DateOnly.Parse(items[6], CultureInfo.InvariantCulture)
            };
        }


        public static implicit operator Division(TercInfo item)
        {
            string? parentId = null;
            string id;

            if (string.IsNullOrWhiteSpace(item.PowiatId))
            {
                parentId = null;
                id = item.WojewodstwoId;
            }
            else if (string.IsNullOrWhiteSpace(item.GminaId))
            {
                parentId = item.WojewodstwoId;
                id = CustomStringProvider.DivisionIdGenerator(
                    item.WojewodstwoId,
                    item.PowiatId);
            }
            else if (item.Type is not null)
            {
                parentId = CustomStringProvider.DivisionIdGenerator(
                    item.WojewodstwoId,
                    item.PowiatId);
                id = CustomStringProvider.DivisionIdGenerator(
                    item.WojewodstwoId,
                    item.PowiatId,
                    $"{item.GminaId}{item.Type.Id}");
            }
            else
            {
                throw new NotImplementedException();
            }

            return new Division
            {
                ParentId = parentId,
                Id = id,
                Name = item.Nazwa1,
                Type = item.TypeName,
            };
        }
    }
}
