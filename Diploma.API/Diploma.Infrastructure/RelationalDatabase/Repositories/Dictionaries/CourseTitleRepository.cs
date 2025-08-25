using AutoMapper;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Microsoft.EntityFrameworkCore;
using UseCaseCourseTitle = Diploma.UseCase.Shared.Models.Dictionaries.CourseTitle;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.Dictionaries
{
    public class CourseTitleRepository : ICourseTitleRepository
    {
        private readonly DiplomaDbContext context;
        private readonly IMapper mapper;


        public CourseTitleRepository(DiplomaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<UseCaseCourseTitle>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await context.CourseTitles.ToListAsync(cancellationToken);
            return mapper.Map<ICollection<UseCaseCourseTitle>>(items);
        }
    }
}
