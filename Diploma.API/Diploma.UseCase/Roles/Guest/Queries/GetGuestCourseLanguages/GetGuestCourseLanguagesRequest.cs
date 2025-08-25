using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseLanguages
{
    public class GetGuestCourseLanguagesRequest : IRequest<IEnumerable<CourseLanguage>>
    {
    }
}
