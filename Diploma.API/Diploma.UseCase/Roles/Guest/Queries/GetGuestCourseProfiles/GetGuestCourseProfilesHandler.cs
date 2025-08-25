using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseProfiles
{
    public class GetGuestCourseProfilesHandler : IRequestHandler<GetGuestCourseProfilesRequest, IEnumerable<CourseProfile>>
    {
        private readonly ICourseProfileRepository courseProfileRepository;


        public GetGuestCourseProfilesHandler(ICourseProfileRepository courseProfileRepository)
        {
            this.courseProfileRepository = courseProfileRepository;
        }


        public async Task<IEnumerable<CourseProfile>> Handle(GetGuestCourseProfilesRequest request, CancellationToken cancellationToken)
        {
            return await courseProfileRepository.GetAllAsync(cancellationToken);
        }
    }
}
