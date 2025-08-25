using AutoMapper;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Microsoft.EntityFrameworkCore;
using UseCaseDiscipline = Diploma.UseCase.Shared.Models.Dictionaries.Discipline;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.Dictionaries
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly DiplomaDbContext context;
        private readonly IMapper mapper;


        public DisciplineRepository(DiplomaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<UseCaseDiscipline>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await context.Disciplines.ToListAsync(cancellationToken);
            return mapper.Map<ICollection<UseCaseDiscipline>>(items);
        }
    }
}
