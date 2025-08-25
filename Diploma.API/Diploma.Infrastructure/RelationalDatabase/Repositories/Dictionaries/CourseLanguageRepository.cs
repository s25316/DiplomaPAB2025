using AutoMapper;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Microsoft.EntityFrameworkCore;
using UseCaseCourseLanguage = Diploma.UseCase.Shared.Models.Dictionaries.CourseLanguage;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.Dictionaries
{
    public class CourseLanguageRepository : ICourseLanguageRepository
    {
        private readonly DiplomaDbContext context;
        private readonly IMapper mapper;


        public CourseLanguageRepository(DiplomaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<UseCaseCourseLanguage>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await context.CourseLanguages.ToListAsync(cancellationToken);
            return mapper.Map<ICollection<UseCaseCourseLanguage>>(items);
        }
    }
}
