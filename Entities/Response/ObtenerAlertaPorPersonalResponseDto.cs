namespace SAB.Backend.Entities.Response
{
    public class ObtenerAlertaPorPersonalResponseDto
    {
        public DetalleObtenerAlertaPorPersonal? detalleAlerta { get; set; }
    }

    public class DetalleObtenerAlertaPorPersonal
    {
        public string? strCodAlerta { get; set; }
        public string? strDepartamento { get; set; }
        public string? strProvincia { get; set; }
        public string? strDistrito { get; set; }
        public string? strDireccion { get; set; }
        public string? strLatitud { get; set; }
        public string? strLongitud { get; set; }
        public string? strDescripcion { get; set; }
        public string? strNombreGrupoPersonal { get; set; }
    }
}
