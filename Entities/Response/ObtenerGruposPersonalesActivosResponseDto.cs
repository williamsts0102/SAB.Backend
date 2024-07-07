namespace SAB.Backend.Entities.Response
{
    public class ObtenerGruposPersonalesActivosResponseDto
    {
        public List<GruposPersonalesActivosDto>? obtenerGruposPersonalesActivos { get; set; }
    }

    public class GruposPersonalesActivosDto
    {
        public int? intIdGrupoPersonal { get; set; }
        public string? strNombreGrupoPersonal { get; set; }
    }
}
