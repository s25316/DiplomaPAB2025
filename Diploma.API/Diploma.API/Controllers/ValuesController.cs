using Microsoft.AspNetCore.Mvc;
using REGON;
using REGON.Enums;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly RegonService _client;

        public ValuesController(RegonService client)
        {
            _client = client;
        }



        [HttpGet]
        public async Task<IActionResult> GetAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken)
        {
            var result = await _client.GetAsync(value, by, cancellationToken);
            return Ok(result);
        }
    }
}
