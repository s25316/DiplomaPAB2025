namespace Diploma.UseCase.Models.Addresses
{
    public record Street
    {
        public string Id { get; init; } = null!;
        public string Name { get; init; } = null!;
        public PairIdName<int>? Type { get; init; }
    }
}
