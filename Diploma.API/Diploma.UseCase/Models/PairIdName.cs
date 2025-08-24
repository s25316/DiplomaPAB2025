namespace Diploma.UseCase.Models
{
    public record PairIdName<TId>
        where TId : notnull
    {
        public required TId Id { get; init; }
        public string Name { get; init; } = null!;
    }
}
