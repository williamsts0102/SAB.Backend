using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SAB.Backend.Business;
using SAB.Backend.Entities.Request;
using SAB.Backend.Models.SAB.DB;
using SAB.Backend.SignalR;
using SAB.Backend.SignalR.Clases;
using System.Net;

namespace SAB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SABController : ControllerBase
    {
        private readonly ISABBO _sabBO;
        private readonly SABContext _context;
        private readonly IHubContext<AlertHub> _alertHubContext;

        public SABController(ISABBO sabBO, SABContext context, IHubContext<AlertHub> alertHubContext)
        {
            _sabBO = sabBO;
            _context = context;
            _alertHubContext = alertHubContext;
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
                var detalleAlerta = await _sabBO.DetalleAlerta(new DetalleAlertaRequestDto { pstrCodAlerta = response.codigoAlerta });
                var alerta = new Alerta()
                {
                    strCodAlerta = detalleAlerta.detalleAlerta.strCodAlerta,
                    strDepartamento = detalleAlerta.detalleAlerta.strDepartamento,
                    strProvincia = detalleAlerta.detalleAlerta.strProvincia,
                    strDistrito = detalleAlerta.detalleAlerta.strDistrito,
                    strDireccion = detalleAlerta.detalleAlerta.strDireccion,
                    strDescripcion = detalleAlerta.detalleAlerta.strDescripcion,
                    strLatitud = detalleAlerta.detalleAlerta.strLatitud,
                    strLongitud = detalleAlerta.detalleAlerta.strLongitud,
                    intIdGrupoPersonal = detalleAlerta.detalleAlerta.intIdGrupoPersonal,
                    bitEstado = detalleAlerta.detalleAlerta.bitEstado
                };
                await _alertHubContext.Clients.All.SendAsync("ReceiveAlert", alerta);
                DisposeResources();
                return StatusCode((int)response.codigo, response.descripcion);
            }
            catch (Exception ex)
            {
                DisposeResources();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("ListarAlerta")]
        public async Task<IActionResult> ListarAlerta()
        {
            try
            {
                var response = await _sabBO.ListarAlerta();
                DisposeResources();
                return Ok(response.listarAlerta);
            }
            catch (Exception ex)
            {
                DisposeResources();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("DetalleAlerta")]
        public async Task<IActionResult> DetalleAlerta([FromBody] DetalleAlertaRequestDto request)
        {
            try
            {
                var response = await _sabBO.DetalleAlerta(request);
                DisposeResources();
                return Ok(response.detalleAlerta);
            }
            catch (Exception ex)
            {
                DisposeResources();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost("ObtenerAlertaPorPersonal")]
        public async Task<IActionResult> ObtenerAlertaPorPersonal([FromBody] ObtenerAlertaPorPersonalRequestDto request)
        {
            try
            {
                var response = await _sabBO.ObtenerAlertaPorPersonal(request);
                DisposeResources();
                return Ok(response.detalleAlerta);
            }
            catch (Exception ex)
            {
                DisposeResources();
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
