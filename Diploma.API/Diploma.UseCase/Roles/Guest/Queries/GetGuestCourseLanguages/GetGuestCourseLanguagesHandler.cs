using Diploma.UseCase.Shared.Interfaces.Repositories.Dictionaries;
using Diploma.UseCase.Shared.Models.Dictionaries;
using MediatR;

namespace Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseLanguages
{
    public class GetGuestCourseLanguagesHandler : IRequestHandler<GetGuestCourseLanguagesRequest, IEnumerable<CourseLanguage>>
    {
        private readonly ICourseLanguageRepository courseLanguageRepository;


        public GetGuestCourseLanguagesHandler(ICourseLanguageRepository courseLanguageRepository)
        {
            this.courseLanguageRepository = courseLanguageRepository;
        }


        public async Task<IEnumerable<CourseLanguage>> Handle(GetGuestCourseLanguagesRequest request, CancellationToken cancellationToken)
        {
            return await courseLanguageRepository.GetAllAsync(cancellationToken);
        }
    }
}
