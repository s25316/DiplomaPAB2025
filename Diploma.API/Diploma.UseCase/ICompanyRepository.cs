using Diploma.UseCase.Models.Companies;

namespace Diploma.UseCase
{
    public interface ICompanyRepository
    {
        Task<Company?> GetAsync(string regon, CancellationToken cancellationToken = default);
    }
}
