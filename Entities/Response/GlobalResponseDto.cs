using System.Net;

namespace SAB.Backend.Entities.Response
{
    public class GlobalResponseDto
    {
        public HttpStatusCode codigo { get; set; }
        public string? descripcion { get; set; }
    }
}
