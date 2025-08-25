using AutoMapper;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Microsoft.EntityFrameworkCore;
using UseCaseCourseLevel = Diploma.UseCase.Shared.Models.Dictionaries.CourseLevel;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.Dictionaries
{
    public class CourseLevelRepository : ICourseLevelRepository
    {
        private readonly DiplomaDbContext context;
        private readonly IMapper mapper;


        public CourseLevelRepository(DiplomaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<UseCaseCourseLevel>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await context.CourseLevels.ToListAsync(cancellationToken);
            return mapper.Map<ICollection<UseCaseCourseLevel>>(items);
        }
    }
}
