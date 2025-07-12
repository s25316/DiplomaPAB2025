using Microsoft.AspNetCore.Mvc;
using REGON;
using REGON.Enums;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly RegonClient _client;

        public ValuesController(RegonClient client)
        {
            _client = client;
        }


        [HttpGet("StatusUslugi")]
        public async Task<IActionResult> GetStatusUslugiAsync(
            CancellationToken cancellationToken)
        {
            var result = await _client.StatusUslugiAsync(cancellationToken);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken)
        {
            var result = await _client.DaneSzukajAsync(value, by, cancellationToken);
            return Ok(result);
        }


        [HttpGet("PobierzPelnyRaport")]
        public async Task<IActionResult> GetPobierzPelnyRaportAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken)
        {
            var result = await _client.PobierzPelnyRaportAsync(value, by, cancellationToken);
            return Ok(result);
        }

        [HttpGet("PobierzPKD")]
        public async Task<IActionResult> PobierzPKDAsync(
            string value,
            GetBy by,
            CancellationToken cancellationToken)
        {
            var result = await _client.PobierzPKDAsync(value, by, cancellationToken);
            return Ok(result);
        }
    }
}
