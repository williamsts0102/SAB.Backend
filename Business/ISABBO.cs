using SAB.Backend.Entities.Request;
using SAB.Backend.Entities.Response;

namespace SAB.Backend.Business
{
    public interface ISABBO
    {
        Task<RegistrarAlertaResponseDto> RegistrarAlerta(RegistrarAlertaRequestDto request);
        Task<ListarAlertaResponseDto> ListarAlerta();
        Task<DetalleAlertaResponseDto> DetalleAlerta(DetalleAlertaRequestDto request);
        Task<ObtenerAlertaPorPersonalResponseDto> ObtenerAlertaPorPersonal(ObtenerAlertaPorPersonalRequestDto request);
        Task<ActualizarAlertaResponseDto> ActualizarAlerta(ActualizarAlertaRequestDto request);
        Task<DescartarAlertaResponseDto> DescartarAlerta(DescartarAlertaRequestDto request);
        Task<ObtenerGruposPersonalesActivosResponseDto> ObtenerGruposPersonalesActivos();
    }
}
