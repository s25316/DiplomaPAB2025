using Diploma.Domain.Shared.ValueObjects;
using Diploma.UseCase.Shared.Models.Companies;

namespace Diploma.UseCase.Shared.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetAsync(
            Regon regon,
            CancellationToken cancellationToken = default);
    }
}
