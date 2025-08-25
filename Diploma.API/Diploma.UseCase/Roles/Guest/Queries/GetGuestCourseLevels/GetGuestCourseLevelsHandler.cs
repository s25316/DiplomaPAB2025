using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseLevels
{
    public class GetGuestCourseLevelsHandler : IRequestHandler<GetGuestCourseLevelsRequest, IEnumerable<CourseLevel>>
    {
        private readonly ICourseLevelRepository courseLevelRepository;


        public GetGuestCourseLevelsHandler(ICourseLevelRepository courseLevelRepository)
        {
            this.courseLevelRepository = courseLevelRepository;
        }


        public async Task<IEnumerable<CourseLevel>> Handle(GetGuestCourseLevelsRequest request, CancellationToken cancellationToken)
        {
            return await courseLevelRepository.GetAllAsync(cancellationToken);
        }
    }
}
