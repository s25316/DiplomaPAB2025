using Diploma.UseCase.Shared.Models;

namespace Diploma.UseCase.Shared.Models.Addresses
{
    public record Street
    {
        public string Id { get; init; } = null!;
        public string Name { get; init; } = null!;
        public PairIdName<int>? Type { get; init; }
    }
}
