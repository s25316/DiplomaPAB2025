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

        [HttpGet("courses")]
        public async Task<IActionResult> GetInstitutionsAsync(
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
    }
}
