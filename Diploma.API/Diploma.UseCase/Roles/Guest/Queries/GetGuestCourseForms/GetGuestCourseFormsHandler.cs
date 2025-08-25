using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseForms
{
    public class GetGuestCourseFormsHandler : IRequestHandler<GetGuestCourseFormsRequest, IEnumerable<CourseForm>>
    {
        private readonly ICourseFormRepository courseFormRepository;


        public GetGuestCourseFormsHandler(ICourseFormRepository courseFormRepository)
        {
            this.courseFormRepository = courseFormRepository;
        }


        public async Task<IEnumerable<CourseForm>> Handle(GetGuestCourseFormsRequest request, CancellationToken cancellationToken)
        {
            return await courseFormRepository.GetAllAsync(cancellationToken);
        }
    }
}
