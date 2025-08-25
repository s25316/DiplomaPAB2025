using AutoMapper;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Microsoft.EntityFrameworkCore;
using UseCaseEducationInstitutionKind = Diploma.UseCase.Shared.Models.Dictionaries.EducationInstitutionKind;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.Dictionaries
{
    public class EducationInstitutionKindRepository : IEducationInstitutionKindRepository
    {
        private readonly DiplomaDbContext context;
        private readonly IMapper mapper;


        public EducationInstitutionKindRepository(DiplomaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<UseCaseEducationInstitutionKind>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await context.EducationInstitutionKinds.ToListAsync(cancellationToken);
            return mapper.Map<ICollection<UseCaseEducationInstitutionKind>>(items);
        }
    }
}
