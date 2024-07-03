namespace SAB.Backend.Models.SAB.DB
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? IdRol { get; set; }
        public int? IdPersonal { get; set; }
        public int? IdCiudadano { get; set; }
        public bool Estado { get; set; }
        public bool Activo { get; set; }
        public bool Eliminado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public virtual Rol? Rol { get; set; }
        public virtual Personal? Personal { get; set; }
        public virtual Ciudadano? Ciudadano { get; set; }
    }
}
