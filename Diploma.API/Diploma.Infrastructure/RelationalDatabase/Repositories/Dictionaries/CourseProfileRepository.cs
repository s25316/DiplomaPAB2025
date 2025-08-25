using AutoMapper;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Microsoft.EntityFrameworkCore;
using UseCaseCourseProfile = Diploma.UseCase.Shared.Models.Dictionaries.CourseProfile;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.Dictionaries
{
    public class CourseProfileRepository : ICourseProfileRepository
    {
        private readonly DiplomaDbContext context;
        private readonly IMapper mapper;


        public CourseProfileRepository(DiplomaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<UseCaseCourseProfile>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await context.CourseProfiles.ToListAsync(cancellationToken);
            return mapper.Map<ICollection<UseCaseCourseProfile>>(items);
        }
    }
}
