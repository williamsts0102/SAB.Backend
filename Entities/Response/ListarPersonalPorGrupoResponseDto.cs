namespace SAB.Backend.Entities.Response
{
    public class ListarPersonalPorGrupoResponseDto
    {
        public List<ListarPersonalPorGrupo>? listarPersonalPorGrupo { get; set; }
    }

    public class ListarPersonalPorGrupo
    {
        public string? strCodPersonal { get; set; }
        public string? strNombreCompleto { get; set; }
        public string? strDNI { get; set; }
        public string? strDireccion { get; set; }
        public string? strTelefono { get; set; }
        public string? strCorreo { get; set; }
    }
}
