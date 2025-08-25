using AutoMapper;
using Diploma.Infrastructure.RelationalDatabase.Base;
using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Microsoft.EntityFrameworkCore;
using UseCaseCourseForm = Diploma.UseCase.Shared.Models.Dictionaries.CourseForm;

namespace Diploma.Infrastructure.RelationalDatabase.Repositories.Dictionaries
{
    public class CourseFormRepository : ICourseFormRepository
    {
        private readonly DiplomaDbContext context;
        private readonly IMapper mapper;


        public CourseFormRepository(DiplomaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<UseCaseCourseForm>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var items = await context.CourseForms.ToListAsync(cancellationToken);
            return mapper.Map<ICollection<UseCaseCourseForm>>(items);
        }
    }
}
