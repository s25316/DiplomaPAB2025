// Ignore Spelling: Regon
using Diploma.UseCase.Models.Addresses;

namespace Diploma.UseCase.Models.Companies
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
        public bool IsEductionInstitution { get; init; }

        public ICollection<CompanyName> Names { get; init; } = [];
        public Address? Address { get; init; }
    }
}
