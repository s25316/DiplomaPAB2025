using Diploma.UseCase.Shared.Models.Companies;
using Diploma.UseCase.Shared.Models.Dictionaries;

namespace Diploma.UseCase.Shared.Models.EductionInstitutions
{
    public record EducationInstitution : Company
    {
        public EducationInstitutionKind Kind { get; init; } = null!;
    }
}
