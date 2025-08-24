using Diploma.UseCase.Models.Companies;

namespace Diploma.UseCase.Models.EductionInstitutions
{
    public record EducationInstitution : Company
    {
        public PairIdName<int> Kind { get; init; } = null!;
    }
}
