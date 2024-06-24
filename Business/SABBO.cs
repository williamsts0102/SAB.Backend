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
                response.descripcion = result.descripcion;
                response.codigoAlerta = result.codigoAlerta;
            }
            catch (Exception ex)
            {
                response.codigo = HttpStatusCode.InternalServerError;
                response.descripcion = ex.Message;
            }
            return response;
        }

        public async Task<ListarAlertaResponseDto> ListarAlerta()
        {
            var response = new ListarAlertaResponseDto();
            try
            {
                var result = await _sabDO.ListarAlerta();
                response.listarAlerta = new List<AlertaListarAlerta>();
                foreach (var item in result)
                {
                    response.listarAlerta.Add(new AlertaListarAlerta
                    {
                        strCodAlerta = item.strCodAlerta,
                        strDepartamento = item.strDepartamento,
                        strProvincia = item.strProvincia,
                        strDistrito = item.strDistrito,
                        strLatitud = item.strLatitud,
                        strLongitud = item.strLongitud,
                        strDescripcion = item.strDescripcion,
                        bitEstado = item.bitEstado
                    });
                }

            }
            catch (Exception ex)
            {
                return response;
            }
            return response;
        }

        public async Task<DetalleAlertaResponseDto> DetalleAlerta(DetalleAlertaRequestDto request)
        {
            var response = new DetalleAlertaResponseDto();
            try
            {
                var parameters = new SP_SAB_DetalleAlerta_Parameters
                {
                    pstrCodAlerta = request.pstrCodAlerta
                };
                var result = await _sabDO.DetalleAlerta(parameters);
                response.detalleAlerta = new AlertaDetalleAlerta
                {
                    strCodAlerta = result.strCodAlerta,
                    strDepartamento = result.strDepartamento,
                    strProvincia = result.strProvincia,
                    strDistrito = result.strDistrito,
                    strLatitud = result.strLatitud,
                    strLongitud = result.strLongitud,
                    strDescripcion = result.strDescripcion,
                    bitEstado = result.bitEstado
                };
            }
            catch (Exception ex)
            {
                response.detalleAlerta = new AlertaDetalleAlerta();
            }
            return response;
        }
    }
}
