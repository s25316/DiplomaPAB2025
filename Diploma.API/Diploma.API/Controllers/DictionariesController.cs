using Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseForms;
using Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseLanguages;
using Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseLevels;
using Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseProfiles;
using Diploma.UseCase.Roles.Guest.Queries.GetGuestCourseTitles;
using Diploma.UseCase.Roles.Guest.Queries.GetGuestDisciplines;
using Diploma.UseCase.Roles.Guest.Queries.GetGuestEducationInstitutionKinds;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        private readonly IMediator mediator;


        public DictionariesController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("institutions/kinds")]
        public async Task<IActionResult> GetGuestEducationInstitutionKindsAsync(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(
                new GetGuestEducationInstitutionKindsRequest(),
                cancellationToken);
            return Ok(result);
        }


        [HttpGet("institutions/courses/forms")]
        public async Task<IActionResult> GetGuestCourseFormsAsync(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(
                new GetGuestCourseFormsRequest(),
                cancellationToken);
            return Ok(result);
        }


        [HttpGet("institutions/courses/languages")]
        public async Task<IActionResult> GetGuestCourseLanguagesAsync(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(
                new GetGuestCourseLanguagesRequest(),
                cancellationToken);
            return Ok(result);
        }


        [HttpGet("institutions/courses/levels")]
        public async Task<IActionResult> GetGuestCourseLevelsAsync(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(
                new GetGuestCourseLevelsRequest(),
                cancellationToken);
            return Ok(result);
        }


        [HttpGet("institutions/courses/profiles")]
        public async Task<IActionResult> GetGuestCourseProfilesAsync(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(
                new GetGuestCourseProfilesRequest(),
                cancellationToken);
            return Ok(result);
        }


        [HttpGet("institutions/courses/titles")]
        public async Task<IActionResult> GetGuestCourseTitlesAsync(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(
                new GetGuestCourseTitlesRequest(),
                cancellationToken);
            return Ok(result);
        }


        [HttpGet("disciplines")]
        public async Task<IActionResult> GetGuestDisciplinesAsync(CancellationToken cancellationToken)
        {
            var result = await mediator.Send(
                new GetGuestDisciplinesRequest(),
                cancellationToken);
            return Ok(result);
        }
    }
}
