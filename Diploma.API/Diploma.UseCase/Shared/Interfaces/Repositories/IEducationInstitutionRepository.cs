using Diploma.Domain.Shared.ValueObjects;
using Diploma.UseCase.Shared.Models.EductionInstitutions;

namespace Diploma.UseCase.Shared.Interfaces.Repositories
{
    public interface IEducationInstitutionRepository
    {
        Task<IEnumerable<EducationInstitution>> GetAsync(
            CancellationToken cancellationToken = default);

        Task<EducationInstitution> GetAsync(
            Regon regon,
            CancellationToken cancellationToken = default);
    }
    // IQueryObject
    public interface IDictionaryRepository<T>
        where T : notnull
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    }

    //public interface ICourseNameRepository : IDictionaryRepository<CourseName> { } // ??
}
