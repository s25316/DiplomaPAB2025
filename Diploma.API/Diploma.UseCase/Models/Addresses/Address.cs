namespace Diploma.UseCase.Models.Addresses
{
    public record Address
    {
        public ICollection<Division> Divisions { get; init; } = [];
        public Street? Street { get; init; }
        public string BuildingNumber { get; init; } = null!;
        public string? FlatNumber { get; init; }
    }
}
