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
            var result = await _client.GetDaneSzukajAsync(value, by, cancellationToken);
            return Ok(result);
        }

        [HttpGet("RaportJednostki")]
        public async Task<IActionResult> PobierzRaportJednostkiAsync(
            CancellationToken cancellationToken,
            string value,
            GetBy by = GetBy.REGON)
        {
            var result = await _client.GetRaportJednostkiAsync(value, by, cancellationToken);
            return Ok(result);
        }

        [HttpGet("RaportJednostkiWithPkd")]
        public async Task<IActionResult> RaportJednostkiWithPkdAsync(
            CancellationToken cancellationToken,
            string value,
            GetBy by = GetBy.REGON)
        {
            var result = await _client.GetRaportJednostkiWithPkdAsync(value, by, cancellationToken);
            return Ok(result);
        }
    }
}
