using Microsoft.AspNetCore.Mvc;
using TerytPlugin;

namespace Diploma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerytController : ControllerBase
    {
        private const string TERC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\TERC.csv";
        private const string SIMC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\SIMC.csv";
        private const string ULIC_FILE = "C:\\01Mine\\git\\DiplomaPAB2025\\Diploma.API\\TerytPlugin\\FIles\\ULIC.csv";


        [HttpGet("any")]
        public async Task<IActionResult> GetAsync()
        {
            var item = await new TerytClient(TERC_FILE, SIMC_FILE, ULIC_FILE)
                .GetAsync();
            return Ok(new { item.StreetTypes, item.DivisionTypes });
        }
    }
}
