using Microsoft.AspNetCore.Mvc;
using RadonPlugin;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadonDictionariesController(RadonClient client) : ControllerBase
    {
        // BRANCHES
        [HttpGet("branch/branchStatuses")]
        public async Task<IActionResult> GetBranchStatusesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetBranchStatusesAsync(cancellationToken);
            return Ok(results);
        }


        // COURSE
        [HttpGet("course/levels")]
        public async Task<IActionResult> GetCourseLevelsAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCourseLevelsAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("course/profiles")]
        public async Task<IActionResult> GetCourseProfilesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCourseProfilesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("course/currentStatuses")]
        public async Task<IActionResult> GetCourseCurrentStatusesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCourseCurrentStatusesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("course/legalBasisTypes")]
        public async Task<IActionResult> GetCourseLegalBasisTypesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCourseLegalBasisTypesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("course/professionalTitles")]
        public async Task<IActionResult> GetCourseProfessionalTitlesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCourseProfessionalTitlesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("course/instanceStatuses")]
        public async Task<IActionResult> GetCourseInstanceStatusesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCourseInstanceStatusesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("course/instanceForms")]
        public async Task<IActionResult> GetCourseInstanceFormsAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCourseInstanceFormsAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("course/philologicalLanguages")]
        public async Task<IActionResult> GetCoursePhilologicalLanguagesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCoursePhilologicalLanguagesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("course/mainInstitutionKinds")]
        public async Task<IActionResult> GetCourseMainInstitutionKindsAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetCourseMainInstitutionKindsAsync(cancellationToken);
            return Ok(results);
        }


        // DOCTORAL SCHOOL
        [HttpGet("doctoralSchool/currentStatuses")]
        public async Task<IActionResult> GetDoctoralSchoolCurrentStatusesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetDoctoralSchoolCurrentStatusesAsync(cancellationToken);
            return Ok(results);
        }


        // INSTITUTIONS
        [HttpGet("institution/institutionKinds")]
        public async Task<IActionResult> GetInstitutionKindsAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetInstitutionKindsAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("institution/institutionStatuses")]
        public async Task<IActionResult> GetInstitutionStatusesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetInstitutionStatusesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("institution/universityTypes")]
        public async Task<IActionResult> GetInstitutionUniversityTypesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetInstitutionUniversityTypesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("institution/scientificInstitutionTypes")]
        public async Task<IActionResult> GetInstitutionScientificTypesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetInstitutionScientificTypesAsync(cancellationToken);
            return Ok(results);
        }


        // SPECIALIZED EDUCATION
        [HttpGet("specialized-education/certificateKinds")]
        public async Task<IActionResult> GetSpecializedEducationCertificateKindsAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetSpecializedEducationCertificateKindsAsync(cancellationToken);
            return Ok(results);
        }


        // SHARED
        [HttpGet("shared/supervisingInstitutions")]
        public async Task<IActionResult> GetSupervisingInstitutionsAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetSupervisingInstitutionsAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("shared/disciplines")]
        public async Task<IActionResult> GetDisciplinesAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetDisciplinesAsync(cancellationToken);
            return Ok(results);
        }


        [HttpGet("shared/domains")]
        public async Task<IActionResult> GetDomainsAsync(
            CancellationToken cancellationToken)
        {
            var results = await client.GetDomainsAsync(cancellationToken);
            return Ok(results);
        }
    }
}
