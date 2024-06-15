using System.Net;

namespace SAB.Backend.Entities.Response
{
    public class GlobalResponseDto
    {
        public HttpStatusCode codigoRes { get; set; }
        public string mensajeRes { get; set; }
    }
}
