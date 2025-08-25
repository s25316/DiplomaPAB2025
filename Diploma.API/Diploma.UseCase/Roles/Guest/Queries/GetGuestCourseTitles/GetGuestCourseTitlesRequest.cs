using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseTitles
{
    public class GetGuestCourseTitlesRequest : IRequest<IEnumerable<CourseTitle>>
    {
    }
}
