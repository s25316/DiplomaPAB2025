using AutoMapper;
using Diploma.Domain.Shared.Exceptions;
using Diploma.Domain.Shared.ValueObjects;
using Diploma.Infrastructure.Exceptions;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase;
using Diploma.UseCase.Models.Companies;
using Microsoft.EntityFrameworkCore;
using RegonPlugin;
using RegonPlugin.Enums;
using RegonPlugin.Enums.GetValues;
using RegonPlugin.Models.DTOs;
using RegonPlugin.Models.Generics;
using DatabaseAddress = Diploma.Infrastructure.RelationalDatabase.Base.Models.Addresses.Address;
using DatabaseCompany = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.Company;
using DatabaseCompanyAddress = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.CompanyAddress;
using DatabaseCompanyName = Diploma.Infrastructure.RelationalDatabase.Base.Models.Companies.CompanyName;
using UseCaseCompany = Diploma.UseCase.Models.Companies.Company;

// Ignore Spelling: regon
namespace Diploma.Infrastructure.RelationalDatabase.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DiplomaDbContext context;
        private readonly RegonService regonService;
        private readonly IMapper mapper;


        public CompanyRepository(
            DiplomaDbContext context,
            RegonService regonService,
            IMapper mapper)
        {
            this.context = context;
            this.regonService = regonService;
            this.mapper = mapper;
        }


        public async Task<Company> GetAsync(
            Regon regon,
            CancellationToken cancellationToken = default)
        {
            var dbCompany = await GetDatabaseCompanyAsync(regon, cancellationToken);

            if (dbCompany == null)
            {
                await GetFromRegonAndSaveToDatabaseAsync(regon, cancellationToken);
                dbCompany = await GetDatabaseCompanyAsync(regon, cancellationToken);
            }

            if (dbCompany == null)
            {
                throw new Resource.NotFoundException($"REGON: {regon}");
            }
            return mapper.Map<UseCaseCompany>(dbCompany);
        }

        private async Task<DatabaseCompany?> GetDatabaseCompanyAsync(
            Regon regon,
            CancellationToken cancellationToken = default)
        {
            return await context.Companies
                .Include(x => x.CompanyNames)
                .Include(x => x.CompanyAddresses)
                .Where(c => c.Regon == regon.Value)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private async Task GetFromRegonAndSaveToDatabaseAsync(
            Regon regon,
            CancellationToken cancellationToken = default)
        {
            var reportResult = await regonService.GetRaportJednostkiAsync(
                regon,
                GetBy.REGON,
                cancellationToken);

            var report = reportResult.Value;
            if (report is null)
            {
                var exception = PrepareRegonException(reportResult, regon);
                throw exception;
            }

            await CreateCompanyAsync(report, cancellationToken);
        }

        private async Task CreateCompanyAsync(
            RaportJednostki report,
            CancellationToken cancellationToken = default)
        {
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
                var e when e.Error is RegonError.BrakUprawnienDoRaportu => new InfrastructureLayer.Regon.ForbiddenException(regon),
                var e when e.Error is RegonError.NiepoprawneDaneWejsciowe => new Resource.InvalidInputException(regon),
                var e when e.Error is RegonError.NieZnalezionoPodmiotów => new Resource.NotFoundException(regon),
                _ => new InfrastructureLayer.Regon.OtherException(regon, response.Error),
            };
        }
    }
}
