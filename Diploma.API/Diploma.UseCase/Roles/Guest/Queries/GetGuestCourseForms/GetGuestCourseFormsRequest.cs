using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseForms
{
    public class GetGuestCourseFormsRequest : IRequest<IEnumerable<CourseForm>>
    {
    }
}
