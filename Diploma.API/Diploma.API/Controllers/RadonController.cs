using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using RadonPlugin;
using RadonPlugin.Enums;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadonController : ControllerBase
    {
        private readonly RadonClient _client;

        public RadonController(RadonClient client)
        {
            _client = client;
        }


        // BRANCHES
        [HttpGet("branches")]
        public async Task<IActionResult> GetInstitutionsAsync(
            GetBranchBy by,
            string value,
            CancellationToken cancellationToken)
        {
            var results = await _client.GetBranchesAsync(by, value, cancellationToken);
            return Ok(results);
        }

        [HttpGet("branchesBy")]
        public IActionResult GetBranchBy()
        {
            var list = Enum.GetValues(typeof(GetBranchBy))
                   .Cast<GetBranchBy>()
                   .Select(e => new { Id = (int)e, Name = e.GetDisplayName() })
                   .ToList();
            return Ok(list);
        }


        // COURSES
        [HttpGet("courses")]
        public async Task<IActionResult> GetCoursesAsync(
            GetCoursesBy by,
            string value,
            CancellationToken cancellationToken)
        {
            var results = await _client.GetCoursesAsync(by, value, cancellationToken);
            return Ok(results);
        }

        [HttpGet("coursesBy")]
        public IActionResult GetCoursesBy()
        {
            var list = Enum.GetValues(typeof(GetCoursesBy))
                   .Cast<GetCoursesBy>()
                   .Select(e => new { Id = (int)e, Name = e.GetDisplayName() })
                   .ToList();
            return Ok(list);
        }


        // DOCTORAL SCHOOLS
        [HttpGet("doctoralSchools")]
        public async Task<IActionResult> GetCoursesAsync(
            GetDoctoralSchoolBy by,
            string value,
            CancellationToken cancellationToken)
        {
            var results = await _client.GetDoctoralSchoolsAsync(by, value, cancellationToken);
            return Ok(results);
        }

        [HttpGet("doctoralSchoolsBy")]
        public IActionResult GetDoctoralSchoolBy()
        {
            var list = Enum.GetValues(typeof(GetDoctoralSchoolBy))
                   .Cast<GetDoctoralSchoolBy>()
                   .Select(e => new { Id = (int)e, Name = e.GetDisplayName() })
                   .ToList();
            return Ok(list);
        }


        // INSTITUTIONS
        [HttpGet("institutions")]
        public async Task<IActionResult> GetInstitutionsAsync(
            GetInstitutionBy by,
            string value,
            CancellationToken cancellationToken)
        {
            var results = await _client.GetInstitutionsAsync(by, value, cancellationToken);
            return Ok(results);
        }

        [HttpGet("institutionsBy")]
        public IActionResult GetInstitutionsBy()
        {
            var list = Enum.GetValues(typeof(GetInstitutionBy))
                   .Cast<GetInstitutionBy>()
                   .Select(e => new { Id = (int)e, Name = e.GetDisplayName() })
                   .ToList();
            return Ok(list);
        }


        // SPECIALIZED EDUCATIONS
        [HttpGet("specializedEducations")]
        public async Task<IActionResult> GetInstitutionsAsync(
            GetSpecializedEducationBy by,
            string value,
            CancellationToken cancellationToken)
        {
            var results = await _client.GetSpecializedEducationsAsync(by, value, cancellationToken);
            return Ok(results);
        }

        [HttpGet("specializedEducationsBy")]
        public IActionResult GetSpecializedEducationBy()
        {
            var list = Enum.GetValues(typeof(GetSpecializedEducationBy))
                   .Cast<GetSpecializedEducationBy>()
                   .Select(e => new { Id = (int)e, Name = e.GetDisplayName() })
                   .ToList();
            return Ok(list);
        }
    }
}
