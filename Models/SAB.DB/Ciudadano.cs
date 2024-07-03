namespace SAB.Backend.Models.SAB.DB
{
    public class Ciudadano
    {
        public int IdCiudadano { get; set; }
        public string CodCiudadano { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string DNI { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }
        public bool Activo { get; set; }
        public bool Eliminado { get; set; }
        public int UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int UsuarioModificacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int UsuarioEliminacion { get; set; }
        public DateTime FechaEliminacion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
