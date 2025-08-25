using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseProfiles
{
    public class GetGuestCourseProfilesRequest : IRequest<IEnumerable<CourseProfile>>
    {
    }
}
