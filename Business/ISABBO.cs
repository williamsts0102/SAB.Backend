using SAB.Backend.Entities.Request;
using SAB.Backend.Entities.Response;

namespace SAB.Backend.Business
{
    public interface ISABBO
    {
        Task<RegistrarAlertaResponseDto> RegistrarAlerta(RegistrarAlertaRequestDto request);
    }
}
