namespace SAB.Backend.Entities.Response
{
    public class ListarGruposPersonalesResponseDto
    {
        public List<ListarGruposPersonales>? listarGruposPersonales { get; set; }
    }
    public class ListarGruposPersonales
    {
        public string? strCodGrupoPersonal { get; set; }
        public string? strNombreGrupoPersonal { get; set; }
        public string? strDescripcionGrupoPersonal { get; set; }
    }
}
