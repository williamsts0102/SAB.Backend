using SAB.Backend.Entities.Request;
using SAB.Backend.Entities.Response;

namespace SAB.Backend.Providers
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResponse> ReturnToken(AuthorizationRequest authorization);
    }
}
