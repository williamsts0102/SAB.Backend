namespace SAB.Backend.Models.SAB.DB
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
