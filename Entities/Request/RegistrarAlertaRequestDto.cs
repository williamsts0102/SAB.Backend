namespace SAB.Backend.Entities.Request
{
    public class RegistrarAlertaRequestDto
    {
        public string? pstrDepartamento { get; set; }
        public string? pstrProvincia { get; set; }
        public string? pstrDistrito { get; set; }
        public string? pstrDireccion { get; set; }
        public string? pstrLatitud { get; set; }
        public string? pstrLongitud { get; set; }
        public string? pstrDescripcion { get; set; }
        public bool? pbitEstado { get; set; }
        public int? pintIdUsuarioRegistro { get; set; }
    }
}
