using AutoMapper;
using Diploma.Infrastructure.Exceptions;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase;
using Diploma.UseCase.Models.Companies;
using Microsoft.EntityFrameworkCore;
using RegonPlugin;
using RegonPlugin.Enums;
using RegonPlugin.Enums.GetValues;
using RegonPlugin.Models.Generics;
using DatabaseAddress = Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses.Address;
using DatabaseCompany = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.Company;
using DatabaseCompanyAddress = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.CompanyAddress;
using DatabaseCompanyName = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.CompanyName;
using UseCaseAddress = Diploma.UseCase.Models.Addresses.Address;
using UseCaseCompanyName = Diploma.UseCase.Models.Companies.CompanyName;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories
{
    public class CompanyRepository(
        DiplomaDbContext context,
        RegonService regonService,
        IAddressRepository addressRepository,
        IMapper mapper)
        : ICompanyRepository
    {
        public async Task<Company?> GetAsync(string regon, CancellationToken cancellationToken = default)
        {
            var dbCompany = await context.Companies
                .Include(x => x.CompanyNames)
                .Include(x => x.EducationInstitution)
                .Include(x => x.CompanyAddresses)
                .Where(c => c.Regon == regon)
                .FirstOrDefaultAsync(cancellationToken);

            if (dbCompany == null)
            {
                await GetFromRegonAndSaveToDatabaseAsync(regon, cancellationToken);
                dbCompany = await context.Companies
                    .Include(x => x.CompanyNames)
                    .Include(x => x.EducationInstitution)
                    .Include(x => x.CompanyAddresses)
                    .Where(c => c.Regon == regon)
                    .FirstOrDefaultAsync(cancellationToken);
            }

            if (dbCompany == null) return null;

            var lastAddressId = dbCompany.CompanyAddresses
                .OrderByDescending(x => x.Date)
                .FirstOrDefault()?
                .AddressId;

            UseCaseAddress? address = null;
            if (lastAddressId is not null)
            {
                address = await addressRepository.GetAsync(
                    lastAddressId.Value,
                    cancellationToken);
            }

            return new Company
            {
                CompanyId = dbCompany.CompanyId,
                CompanyShortName = dbCompany.CompanyShortName,
                Regon = dbCompany.Regon,
                Website = dbCompany.Website,
                PhoneNumber = dbCompany.PhoneNumber,
                Email = dbCompany.Email,
                StartDate = dbCompany.StartDate,
                EndDate = dbCompany.EndDate,
                IsEductionInstitution = dbCompany.EducationInstitution != null,
                Address = address,
                Names = mapper.Map<ICollection<UseCaseCompanyName>>(dbCompany.CompanyNames),
            };
        }

        private async Task GetFromRegonAndSaveToDatabaseAsync(
            string regon,
            CancellationToken cancellationToken = default)
        {
            var reportResult = await regonService
                .GetRaportJednostkiAsync(regon, GetBy.REGON, cancellationToken);

            var report = reportResult.Value;
            if (report is null)
            {
                var exception = PrepareRegonException(reportResult, regon);
                throw exception;
            }

            var lastUpdateDate = report.Daty.DataZmiany
                ?? report.Daty.DataPowstania;


            var dbCompany = new DatabaseCompany
            {
                CompanyShortName = report.NazwaSkrocona,
                Regon = report.Regon,
                Website = report.Kontakty?.WWW.FirstOrDefault(),
                Email = report.Kontakty?.Email.FirstOrDefault(),
                PhoneNumber = report.Kontakty?.NumerTelefonu.FirstOrDefault()
                    ?? report.Kontakty?.NumerWewnetrznyTelefonu.FirstOrDefault(),
                StartDate = report.Daty.DataRozpoczecia,
                EndDate = report.Daty.DataZakonczenia,
            };

            var dbCompanyName = new DatabaseCompanyName
            {
                Company = dbCompany,
                Name = report.Nazwa,
                Date = lastUpdateDate,
            };
            await context.Companies.AddAsync(dbCompany);
            await context.CompanyNames.AddAsync(dbCompanyName);

            if (report.Adres is not null)
            {
                var divisionId = report.Adres.Miejscowosc.Symbol;
                var streetId = report.Adres.Ulica?.Symbol;
                var buildingNumber = report.Adres.NumerNieruchomosci;
                var flatNumber = report.Adres.NumerLokalu;

                var dbAddress = await context.Addresses
                    .Where(a =>
                        a.DivisionId == divisionId &&
                        a.StreetId == streetId &&
                        a.BuildingNumber == buildingNumber &&
                        a.FlatNumber == flatNumber
                    )
                    .FirstOrDefaultAsync(cancellationToken);

                if (dbAddress is null)
                {
                    dbAddress = new DatabaseAddress
                    {
                        DivisionId = divisionId,
                        StreetId = streetId,
                        BuildingNumber = buildingNumber,
                        FlatNumber = flatNumber,
                    };
                    await context.Addresses.AddAsync(dbAddress);
                }

                var dbAddressCompany = new DatabaseCompanyAddress
                {
                    Company = dbCompany,
                    Address = dbAddress,
                    Date = lastUpdateDate,
                };
                await context.CompanyAddresses.AddAsync(dbAddressCompany);
            }

            await context.SaveChangesAsync();
        }

        private static Exception PrepareRegonException<T>(Response<T> response, string regon)
            where T : class
        {
            return response switch
            {
                var r when r.StatusUslugi is StatusUslugi.UslugaNiedostepna => new InfrastructureLayer.Regon.ServiceNotWorkingException(),
                var r when r.StatusUslugi is StatusUslugi.PrzerwaTechniczna => new InfrastructureLayer.Regon.MaintenanceBreakException(),
                var e when e.Error is RegonError.NiepoprawneDaneWejsciowe => new InfrastructureLayer.Regon.InvalidInputException(regon),
                var e when e.Error is RegonError.NieZnalezionoPodmiotów => new InfrastructureLayer.Regon.NotFoundException(regon),
                _ => new InfrastructureLayer.Regon.OtherException(regon, response.Error),
            };
        }
    }
}
