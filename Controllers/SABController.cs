using Microsoft.AspNetCore.Mvc;
using SAB.Backend.Business;
using SAB.Backend.Models.SAB.DB;

namespace SAB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SABController : ControllerBase
    {
        private readonly ISABBO _sabBO;
        private readonly SABContext _context;

        public SABController(ISABBO sabBO, SABContext context)
        {
            _sabBO = sabBO;
            _context = context;
        }

        private void DisposeResources()
        {
            _context.Dispose();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("_sabBO.Get()");
        }
    }
}
