namespace SAB.Backend.Entities.Response
{
    public class ListarAlertaResponseDto
    {
        public List<AlertaListarAlerta>? listarAlerta { get; set; }
    }

    public class AlertaListarAlerta
    {
        public string? strCodAlerta { get; set; }
        public string? strDepartamento { get; set; }
        public string? strProvincia { get; set; }
        public string? strDistrito { get; set; }
        public string? strDescripcion { get; set; }
        public string? strLatitud { get; set; }
        public string? strLongitud { get; set; }
        public bool? bitEstado { get; set; }
    }
}
