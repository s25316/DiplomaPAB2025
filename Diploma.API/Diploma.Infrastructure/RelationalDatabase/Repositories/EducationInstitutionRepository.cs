using AutoMapper;
using Diploma.Domain.Shared.Exceptions;
using Diploma.Domain.Shared.ValueObjects;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase;
using Microsoft.EntityFrameworkCore;
using DatabaseEducationInstitution = Diploma.Infrastructure.RelationalDatabase.Base.Models.EducationInstitutions.EducationInstitution;
using UseCaseEducationInstitution = Diploma.UseCase.Models.EductionInstitutions.EducationInstitution;

// Ignore Spelling: Regon
namespace Diploma.Infrastructure.RelationalDatabase.Repositories
{
    public class EducationInstitutionRepository : IEducationInstitutionRepository
    {
        private readonly DiplomaDbContext context;
        private readonly IMapper mapper;


        public EducationInstitutionRepository(
            DiplomaDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<UseCaseEducationInstitution>> GetAsync(CancellationToken cancellationToken = default)
        {
            var dbEducationInstitutions = await GetDatabaseEducationInstitutionsAsync(cancellationToken);
            return mapper.Map<IEnumerable<UseCaseEducationInstitution>>(dbEducationInstitutions);
        }

        public async Task<UseCaseEducationInstitution> GetAsync(
            Regon regon,
            CancellationToken cancellationToken = default)
        {
            var dbEducationInstitution = await GetDatabaseEducationInstitutionAsync(
                regon,
                cancellationToken)
                ?? throw new Resource.NotFoundException($"REGON: {regon}");

            return mapper.Map<UseCaseEducationInstitution>(dbEducationInstitution);
        }


        private async Task<DatabaseEducationInstitution?> GetDatabaseEducationInstitutionAsync(
            Regon regon,
            CancellationToken cancellationToken = default)
        {
            return await context.EducationInstitutions
                .Include(x => x.Company)
                .ThenInclude(x => x.CompanyAddresses)
                .Include(x => x.Company)
                .ThenInclude(x => x.CompanyNames)
                .Include(x => x.Kind)
                .Where(ei => ei.Company.Regon == regon.Value)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private async Task<IEnumerable<DatabaseEducationInstitution>> GetDatabaseEducationInstitutionsAsync(
            CancellationToken cancellationToken = default)
        {
            return await context.EducationInstitutions
                .Include(x => x.Company)
                .ThenInclude(x => x.CompanyAddresses)
                .Include(x => x.Company)
                .ThenInclude(x => x.CompanyNames)
                .Include(x => x.Kind)
                .ToListAsync(cancellationToken);
        }
    }
}
