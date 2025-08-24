using Diploma.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(ICompanyRepository companyRepository) : ControllerBase
    {


        [HttpGet("company/{regon}")]
        public async Task<IActionResult> GetComapnyAsync(
            string regon,
            CancellationToken cancellationToken = default)
        {
            var result = await companyRepository.GetAsync(regon, cancellationToken);
            return Ok(result);
        }
    }
}
