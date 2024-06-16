using SAB.Backend.DataAccess;
using SAB.Backend.Entities.Request;
using SAB.Backend.Entities.Response;
using SAB.Backend.Models.SAB.DB.Alerta.Parameters;
using System.Net;

namespace SAB.Backend.Business
{
    public class SABBO  : ISABBO
    {
        private readonly ISABDO _sabDO;

        public SABBO(ISABDO sabDO)
        {
            _sabDO = sabDO;
        }

        public async Task<RegistrarAlertaResponseDto> RegistrarAlerta(RegistrarAlertaRequestDto request)
        {
            var response = new RegistrarAlertaResponseDto();
            try
            {
                var parameters = new SP_SAB_DTS_RegistrarAlerta_Parameters
                {
                    pstrDepartamento = request.pstrDepartamento,
                    pstrProvincia = request.pstrProvincia,
                    pstrDistrito = request.pstrDistrito,
                    pstrDireccion = request.pstrDireccion,
                    pstrLatitud = request.pstrLatitud,
                    pstrLongitud = request.pstrLongitud,
                    pstrDescripcion = request.pstrDescripcion,
                    pbitEstado = request.pbitEstado,
                    pintIdUsuarioRegistro = request.pintIdUsuarioRegistro
                };
                var result = await _sabDO.RegistrarAlerta(parameters);
                response.codigo = (HttpStatusCode)result.codigo!;
                response.descripcion = result.descripcion!;
            }
            catch (Exception ex)
            {
                response.codigo = HttpStatusCode.InternalServerError;
                response.descripcion = ex.Message;
            }
            return response;
        }
    }
}
