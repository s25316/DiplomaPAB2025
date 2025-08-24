using Diploma.Domain.Shared.ValueObjects;
using Diploma.UseCase.Models.Companies;

namespace Diploma.UseCase
{
    public interface ICompanyRepository
    {
        Task<Company> GetAsync(
            Regon regon,
            CancellationToken cancellationToken = default);
    }
}
