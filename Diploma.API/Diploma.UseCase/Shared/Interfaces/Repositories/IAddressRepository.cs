using UseCaseAddress = Diploma.UseCase.Shared.Models.Addresses.Address;

namespace Diploma.UseCase.Shared.Interfaces.Repositories
{
    public interface IReadOnlyRepository<TId, T>
        where TId : notnull
        where T : class
    {
        Task<T> GetAsync(TId id, CancellationToken cancellationToken = default);
    }

    public interface IAddressRepository : IReadOnlyRepository<Guid, UseCaseAddress>
    {
    }
}
