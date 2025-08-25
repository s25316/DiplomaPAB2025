using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseTitles
{
    public class GetGuestCourseTitlesHandler : IRequestHandler<GetGuestCourseTitlesRequest, IEnumerable<CourseTitle>>
    {
        private readonly ICourseTitleRepository courseTitleRepository;


        public GetGuestCourseTitlesHandler(ICourseTitleRepository courseTitleRepository)
        {
            this.courseTitleRepository = courseTitleRepository;
        }


        public async Task<IEnumerable<CourseTitle>> Handle(GetGuestCourseTitlesRequest request, CancellationToken cancellationToken)
        {
            return await courseTitleRepository.GetAllAsync(cancellationToken);
        }
    }
}
