using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseLevels
{
    public class GetGuestCourseLevelsRequest : IRequest<IEnumerable<CourseLevel>>
    {
    }
}
