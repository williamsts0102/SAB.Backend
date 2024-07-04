namespace SAB.Backend.Models.SAB.DB.Alerta.Result
{
    public class SP_SAB_ListarAlerta_Result
    {
        public string? strCodAlerta { get; set; }
        public string? strDepartamento { get; set; }
        public string? strProvincia { get; set; }
        public string? strDistrito { get; set; }
        public string? strDireccion { get; set; }
        public string? strDescripcion { get; set; }
        public string? strLatitud { get; set; }
        public string? strLongitud { get; set; }
        public int? intIdGrupoPersonal { get; set; }
        public bool? bitEstado { get; set; }
    }
}
