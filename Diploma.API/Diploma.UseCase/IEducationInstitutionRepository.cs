using Diploma.Domain.Shared.ValueObjects;
using Diploma.UseCase.Models.EductionInstitutions;

namespace Diploma.UseCase
{
    public interface IEducationInstitutionRepository
    {
        Task<IEnumerable<EducationInstitution>> GetAsync(
            CancellationToken cancellationToken = default);

        Task<EducationInstitution> GetAsync(
            Regon regon,
            CancellationToken cancellationToken = default);
    }

}
