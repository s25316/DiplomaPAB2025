using Diploma.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(ICompanyRepository companyRepository, IEducationInstitutionRepository educationInstitutionRepository) : ControllerBase
    {
        [HttpGet("companies")]
        public async Task<IActionResult> GetComapnyAsync(
            [FromQuery] string regon,
            CancellationToken cancellationToken = default)
        {
            var result = await companyRepository.GetAsync(regon, cancellationToken);
            return Ok(result);
        }

        [HttpGet("educationInstitutions")]
        public async Task<IActionResult> GetEDUAsync(
            [FromQuery] string regon,
            CancellationToken cancellationToken = default)
        {
            var result = await educationInstitutionRepository.GetAsync(regon, cancellationToken);
            return Ok(result);
        }

        [HttpGet("educationInstitutions/all")]
        public async Task<IActionResult> GetEDUAsync(
            CancellationToken cancellationToken = default)
        {
            var result = await educationInstitutionRepository.GetAsync(cancellationToken);
            return Ok(result);
        }
    }
}
