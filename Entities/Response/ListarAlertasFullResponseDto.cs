namespace SAB.Backend.Entities.Response
{
    public class ListarAlertasFullResponseDto
    {

        public List<ListarAlertasFull>? listarAlertasFull { get; set; }
    }

    public class ListarAlertasFull
    {
        public bool? bitEstado { get; set; }
        public bool? bitEliminado { get; set; }
    }

}
