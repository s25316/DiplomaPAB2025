using AutoMapper;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase;
using Microsoft.EntityFrameworkCore;
using UseCaseAddress = Diploma.UseCase.Models.Addresses.Address;
using UseCaseDivison = Diploma.UseCase.Models.Addresses.Division;
using UseCaseStreet = Diploma.UseCase.Models.Addresses.Street;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories
{
    public class AddressRepository(DiplomaDbContext context, IMapper mapper) : IAddressRepository
    {
        public async Task<UseCaseAddress> GetAsync(
            Guid addressId,
            CancellationToken cancellationToken = default)
        {
            var dbAddress = await context.Addresses
                .Include(x => x.Street)
                .ThenInclude(x => x.StreetType)
                .Where(a => a.AddressId == addressId)
                .FirstOrDefaultAsync(cancellationToken);

            if (dbAddress is null) throw new Exception();

            // Street Part
            UseCaseStreet? street = null;
            if (dbAddress.Street is not null)
            {
                street = mapper.Map<UseCaseStreet>(dbAddress.Street);
            }

            // Divisions Part
            var divisions = new List<UseCaseDivison>();
            string? divisionId = dbAddress.DivisionId;

            do
            {
                var divison = await context.Divisions
                    .Include(x => x.DivisionType)
                    .Where(x => x.DivisionId == divisionId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (divison is not null)
                {
                    divisions.Add(mapper.Map<UseCaseDivison>(divison));
                }

                divisionId = divison?.ParentDivisionId;

            } while (divisionId is not null);

            divisions.Reverse();
            return new UseCaseAddress
            {
                Street = street,
                Divisions = divisions,
                BuildingNumber = dbAddress.BuildingNumber,
                FlatNumber = dbAddress.FlatNumber,
            };
        }
    }
}
