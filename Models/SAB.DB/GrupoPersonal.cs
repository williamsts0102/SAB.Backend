namespace SAB.Backend.Models.SAB.DB
{
    public class GrupoPersonal
    {
        public int IdGrupoPersonal { get; set; }

        public string CodGrupoPersonal { get; set; }

        public string NombreGrupoPersonal { get; set; }

        public string DescripcionGrupoPersonal { get; set; }

        public bool? Estado { get; set; }

        public bool? Activo { get; set; }

        public bool? Eliminado { get; set; }

        public int? UsuarioRegistro { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public int? UsuarioModificacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public int? UsuarioEliminacion { get; set; }

        public DateTime? FechaEliminacion { get; set; }

        public virtual ICollection<Personal> Personal { get; set; } = new List<Personal>();
    }
}
