using Microsoft.AspNetCore.Mvc;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegonController : ControllerBase
    {
        private readonly RegonPlugin.RegonService _client;

        public RegonController(RegonPlugin.RegonService client)
        {
            _client = client;
        }



        [HttpGet("daneSzukaj")]
        public async Task<IActionResult> DaneSzukajAsync(
            string value,
            RegonPlugin.Enums.GetBy by,
            CancellationToken cancellationToken)
        {
            var result = await _client.DaneSzukajAsync(value, by, cancellationToken);
            return Ok(result);
        }

        [HttpGet("RaportJednostki")]
        public async Task<IActionResult> PobierzRaportJednostkiAsync(
            string value,
            RegonPlugin.Enums.GetBy by,
            CancellationToken cancellationToken)
        {
            var result = await _client.PobierzRaportJednostkiAsync(value, by, cancellationToken);
            return Ok(result);
        }
    }
}
