using Microsoft.AspNetCore.Mvc;
using RegonPlugin.Enums;

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
            CancellationToken cancellationToken,
            string value,
            GetBy by = GetBy.REGON)
        {
            var result = await _client.DaneSzukajAsync(value, by, cancellationToken);
            return Ok(result);
        }

        [HttpGet("RaportJednostki")]
        public async Task<IActionResult> PobierzRaportJednostkiAsync(
            CancellationToken cancellationToken,
            string value,
            GetBy by = GetBy.REGON)
        {
            var result = await _client.PobierzRaportJednostkiAsync(value, by, cancellationToken);
            return Ok(result);
        }
    }
}
