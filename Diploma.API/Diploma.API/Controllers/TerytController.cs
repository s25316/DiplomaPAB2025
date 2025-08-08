using Microsoft.AspNetCore.Mvc;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerytController : ControllerBase
    {
        [HttpGet("terc")]
        public async Task<IActionResult> GetTercInfoAsync()
        {
            var items = await new TerytPlugin.TerytClient().GetTercInfoAsync();
            return Ok(items);
        }


        [HttpGet("simc")]
        public async Task<IActionResult> GetSimcInfoAsync()
        {
            var items = await new TerytPlugin.TerytClient().GetSimcInfoAsync();
            return Ok(items.Take(500));
        }


        [HttpGet("ulic")]
        public async Task<IActionResult> GetUlicInfoAsync()
        {
            var items = await new TerytPlugin.TerytClient().GetUlicInfoAsync();
            return Ok(items.Take(500));
        }
    }
}
