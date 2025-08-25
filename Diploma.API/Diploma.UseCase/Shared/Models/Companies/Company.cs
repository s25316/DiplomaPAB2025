// Ignore Spelling: Regon
namespace Diploma.UseCase.Shared.Models.Companies
{
    public record Company
    {
        public Guid CompanyId { get; init; }
        public string? CompanyShortName { get; init; }
        public string? Regon { get; init; }
        public string? Website { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init; }
        public DateOnly StartDate { get; init; }
        public DateOnly? EndDate { get; init; }

        public ICollection<CompanyName> Names { get; init; } = [];
        public ICollection<CompanyAddress> Addresses { get; init; } = [];
    }
}
