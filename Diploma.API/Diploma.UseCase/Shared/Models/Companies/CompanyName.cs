namespace Diploma.UseCase.Shared.Models.Companies
{
    public record CompanyName
    {
        public string Name { get; init; } = null!;
        public DateOnly Date { get; init; }
    }
}
