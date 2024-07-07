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
                        strDireccion = item.strDireccion,
                        strDescripcion = item.strDescripcion,
                        strLatitud = item.strLatitud,
                        strLongitud = item.strLongitud,
                        intIdGrupoPersonal = item.intIdGrupoPersonal,
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
                    strDireccion = result.strDireccion,
                    strDescripcion = result.strDescripcion,
                    strLatitud = result.strLatitud,
                    strLongitud = result.strLongitud,
                    intIdGrupoPersonal = result.intIdGrupoPersonal,
                    bitEstado = result.bitEstado
                };
            }
            catch (Exception ex)
            {
                response.detalleAlerta = new AlertaDetalleAlerta();
            }
            return response;
        }

        public async Task<ObtenerAlertaPorPersonalResponseDto> ObtenerAlertaPorPersonal(ObtenerAlertaPorPersonalRequestDto request)
        {
            var response = new ObtenerAlertaPorPersonalResponseDto();
            try
            {
                var parameters = new SP_SAB_ObtenerAlertaPorPersonal_Parameters
                {
                    pintIdPersonal = request.pintIdPersonal
                };
                var result = await _sabDO.ObtenerAlertaPorPersonal(parameters);
                response.detalleAlerta = new DetalleObtenerAlertaPorPersonal
                {
                    strCodAlerta = result.strCodAlerta,
                    strDepartamento = result.strDepartamento,
                    strProvincia = result.strProvincia,
                    strDistrito = result.strDistrito,
                    strDireccion = result.strDireccion,
                    strDescripcion = result.strDescripcion,
                    strLatitud = result.strLatitud,
                    strLongitud = result.strLongitud,
                    strNombreGrupoPersonal = result.strNombreGrupoPersonal
                };
            }
            catch (Exception ex)
            {
                response.detalleAlerta = new DetalleObtenerAlertaPorPersonal();
            }
            return response;
        }

        public async Task<ActualizarAlertaResponseDto> ActualizarAlerta(ActualizarAlertaRequestDto request)
        {
            var response = new ActualizarAlertaResponseDto();
            try
            {
                var parameters = new SP_SAB_ActualizarAlerta_Parameters
                {
                    pintIdGrupoPersonal = request.pintIdGrupoPersonal,
                    pstrCodAlerta = request.pstrCodAlerta
                };
                var result = await _sabDO.ActualizarAlerta(parameters);
                response.codigo = (HttpStatusCode)result.codigo!;
                response.descripcion = result.descripcion;
            }
            catch (Exception ex)
            {
                response.codigo = HttpStatusCode.InternalServerError;
                response.descripcion = ex.Message;
            }
            return response;
        }

        public async Task<DescartarAlertaResponseDto> DescartarAlerta(DescartarAlertaRequestDto request)
        {
            var response = new DescartarAlertaResponseDto();
            try
            {
                var parameters = new SP_SAB_DescartarAlerta_Parameters
                {
                    pstrCodAlerta = request.pstrCodAlerta
                };
                var result = await _sabDO.DescartarAlerta(parameters);
                response.codigo = (HttpStatusCode)result.codigo!;
                response.descripcion = result.descripcion;
            }
            catch (Exception ex)
            {
                response.codigo = HttpStatusCode.InternalServerError;
                response.descripcion = ex.Message;
            }
            return response;
        }

        public async Task<ObtenerGruposPersonalesActivosResponseDto> ObtenerGruposPersonalesActivos()
        {
            var response = new ObtenerGruposPersonalesActivosResponseDto();
            try
            {
                var result = await _sabDO.ObtenerGruposPersonalesActivos();
                response.obtenerGruposPersonalesActivos = new List<GruposPersonalesActivosDto>();
                foreach (var item in result)
                {
                    response.obtenerGruposPersonalesActivos.Add(new GruposPersonalesActivosDto
                    {
                        intIdGrupoPersonal = item.intIdGrupoPersonal,
                        strNombreGrupoPersonal = item.strNombreGrupoPersonal
                    });
                }
            }
            catch (Exception ex)
            {
                response.obtenerGruposPersonalesActivos = new List<GruposPersonalesActivosDto>();
            }
            return response;
        }

        public async Task<ListarAlertasFullResponseDto> ListarAlertasFull()
        {
            var response = new ListarAlertasFullResponseDto();
            try
            {
                var result = await _sabDO.ListarAlertasFull();
                response.listarAlertasFull = new List<ListarAlertasFull>();
                foreach (var item in result)
                {
                    response.listarAlertasFull.Add(new ListarAlertasFull
                    {
                        bitEstado = item.bitEstado,
                        bitEliminado = item.bitEliminado
                    });
                }
            }
            catch (Exception ex)
            {
                response.listarAlertasFull = new List<ListarAlertasFull>();
            }
            return response;
        }

        public async Task<ListarGruposPersonalesResponseDto> ListarGruposPersonales()
        {
            var response = new ListarGruposPersonalesResponseDto();
            try
            {
                var result = await _sabDO.ListarGruposPersonales();
                response.listarGruposPersonales = new List<ListarGruposPersonales>();
                foreach (var item in result)
                {
                    response.listarGruposPersonales.Add(new ListarGruposPersonales
                    {
                        strCodGrupoPersonal = item.strCodGrupoPersonal,
                        strNombreGrupoPersonal = item.strNombreGrupoPersonal,
                        strDescripcionGrupoPersonal = item.strDescripcionGrupoPersonal
                    });
                }
            }
            catch (Exception ex)
            {
                response.listarGruposPersonales = new List<ListarGruposPersonales>();
            }
            return response;
        }

        public async Task<ListarPersonalPorGrupoResponseDto> ListarPersonalPorGrupo(ListarPersonalPorGrupoRequestDto request)
        {
            var response = new ListarPersonalPorGrupoResponseDto();
            try
            {
                var parameters = new SP_SAB_ListarPersonalPorGrupo_Parameters
                {
                    pstrCodGrupoPersonal = request.pstrCodGrupoPersonal
                };
                var result = await _sabDO.ListarPersonalPorGrupo(parameters);
                response.listarPersonalPorGrupo = new List<ListarPersonalPorGrupo>();
                foreach (var item in result)
                {
                    response.listarPersonalPorGrupo.Add(new ListarPersonalPorGrupo
                    {
                        strCodPersonal = item.strCodPersonal,
                        strNombreCompleto = item.strNombreCompleto,
                        strDNI = item.strDNI,
                        strDireccion = item.strDireccion,
                        strTelefono = item.strTelefono,
                        strCorreo = item.strCorreo
                    });
                }
            }
            catch (Exception ex)
            {
                response.listarPersonalPorGrupo = new List<ListarPersonalPorGrupo>();
            }
            return response;
        }
    }

}
