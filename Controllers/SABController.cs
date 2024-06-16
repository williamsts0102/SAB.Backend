using Microsoft.AspNetCore.Mvc;
using SAB.Backend.Business;
using SAB.Backend.Entities.Request;
using SAB.Backend.Models.SAB.DB;
using System.Net;

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

        [HttpPost("RegistrarAlerta")]
        public async Task<IActionResult> RegistrarAlerta([FromBody] RegistrarAlertaRequestDto request)
        {
            try
            {
                var response = await _sabBO.RegistrarAlerta(request);
                DisposeResources();
                return StatusCode((int)response.codigo, response.descripcion);
            }
            catch (Exception ex)
            {
                DisposeResources();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
