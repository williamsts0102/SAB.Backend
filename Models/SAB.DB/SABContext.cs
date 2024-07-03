using Microsoft.EntityFrameworkCore;
using SAB.Backend.Models.SAB.DB.Alerta.Result;

namespace SAB.Backend.Models.SAB.DB
{
    public partial class SABContext : DbContext
    {
        public SABContext()
        {
        }

        public SABContext(DbContextOptions<SABContext> options)
            : base(options)
        {
        }

        public DbSet<SP_SAB_DTS_RegistrarAlerta_Result> SP_SAB_DTS_RegistrarAlerta { get; set; }
        public DbSet<SP_SAB_ListarAlerta_Result> SP_SAB_ListarAlerta { get; set; }
        public DbSet<SP_SAB_DetalleAlerta_Result> SP_SAB_DetalleAlerta { get; set; }
        public DbSet<SP_SAB_ObtenerAlertaPorPersonal_Result> SP_SAB_ObtenerAlertaPorPersonal { get; set; }

        public virtual DbSet<Personal> tblPersonal { get; set; }
        public virtual DbSet<Ciudadano> tblCiudadano { get; set; }
        public virtual DbSet<Usuario> tblUsuario { get; set; }
        public virtual DbSet<Rol> tblRol { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrupoPersonal>(entity =>
            {
                entity.HasKey(e => e.IdGrupoPersonal).HasName("PK_GRUPO_PERSONAL");

                entity.ToTable("tblGrupoPersonal");

                entity.Property(e => e.IdGrupoPersonal).HasColumnName("intIdGrupoPersonal");
                entity.Property(e => e.CodGrupoPersonal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strCodGrupoPersonal");
                entity.Property(e => e.NombreGrupoPersonal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strNombreGrupoPersonal");
                entity.Property(e => e.DescripcionGrupoPersonal)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionGrupoPersonal");
                entity.Property(e => e.Estado).HasColumnName("bitEstado");
                entity.Property(e => e.Activo).HasColumnName("bitActivo");
                entity.Property(e => e.Eliminado).HasColumnName("bitEliminado");
                entity.Property(e => e.UsuarioRegistro).HasColumnName("intIdUsuarioRegistro");
                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaRegistro");
                entity.Property(e => e.UsuarioModificacion).HasColumnName("intIdUsuarioModificacion");
                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaModificacion");
                entity.Property(e => e.UsuarioEliminacion).HasColumnName("intIdUsuarioEliminacion");
                entity.Property(e => e.FechaEliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaEliminacion");

                entity.HasMany(e => e.Personal)
                    .WithOne(p => p.GrupoPersonal)
                    .HasForeignKey(p => p.IdGrupoPersonal)
                    .HasConstraintName("FK_PERSONAL_GRUPOPERSONAL");
            });


            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPersonal).HasName("PK_PERSONAL");

                entity.ToTable("tblPersonal");

                entity.Property(e => e.IdPersonal).HasColumnName("intIdPersonal");
                entity.Property(e => e.IdGrupoPersonal).HasColumnName("intIdGrupoPersonal");
                entity.Property(e => e.CodPersonal)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strCodPersonal");
                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strNombres");
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strApellidos");
                entity.Property(e => e.DNI)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("strDNI");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strDireccion");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("strTelefono");
                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strCorreo");
                entity.Property(e => e.Usuario)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strUsuario");
                entity.Property(e => e.Contrasena)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strContrasena");
                entity.Property(e => e.Estado).HasColumnName("bitEstado");
                entity.Property(e => e.Activo).HasColumnName("bitActivo");
                entity.Property(e => e.Eliminado).HasColumnName("bitEliminado");
                entity.Property(e => e.UsuarioRegistro).HasColumnName("intIdUsuarioRegistro");
                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaRegistro");
                entity.Property(e => e.UsuarioModificacion).HasColumnName("intIdUsuarioModificacion");
                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaModificacion");
                entity.Property(e => e.UsuarioEliminacion).HasColumnName("intIdUsuarioEliminacion");
                entity.Property(e => e.FechaEliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaEliminacion");

                entity.HasOne(d => d.GrupoPersonal)
                    .WithMany(p => p.Personal)
                    .HasForeignKey(d => d.IdGrupoPersonal)
                    .HasConstraintName("FK_PERSONAL_GRUPOPERSONAL");
            });

            modelBuilder.Entity<Ciudadano>(entity =>
            {
                entity.HasKey(e => e.IdCiudadano).HasName("PK_CIUDADANO");

                entity.ToTable("tblCiudadano");

                entity.Property(e => e.IdCiudadano).HasColumnName("intIdCiudadano");
                entity.Property(e => e.CodCiudadano)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strCodCiudadano");
                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strNombres");
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strApellidos");
                entity.Property(e => e.DNI)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("strDNI");
                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strDireccion");
                entity.Property(e => e.Telefono)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("strTelefono");
                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strCorreo");
                entity.Property(e => e.Estado).HasColumnName("bitEstado");
                entity.Property(e => e.Activo).HasColumnName("bitActivo");
                entity.Property(e => e.Eliminado).HasColumnName("bitEliminado");
                entity.Property(e => e.UsuarioRegistro).HasColumnName("intIdUsuarioRegistro");
                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaRegistro");
                entity.Property(e => e.UsuarioModificacion).HasColumnName("intIdUsuarioModificacion");
                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaModificacion");
                entity.Property(e => e.UsuarioEliminacion).HasColumnName("intIdUsuarioEliminacion");
                entity.Property(e => e.FechaEliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaEliminacion");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol).HasName("PK_ROLES");

                entity.ToTable("tblRol");

                entity.Property(e => e.IdRol).HasColumnName("intIdRol");
                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("strNombreRol");

                entity.HasMany(e => e.Usuarios)
                    .WithOne(u => u.Rol)
                    .HasForeignKey(u => u.IdRol)
                    .HasConstraintName("FK_USUARIOS_ROL");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario).HasName("PK_USUARIOS");

                entity.ToTable("tblUsuario");

                entity.Property(e => e.IdUsuario).HasColumnName("intIdUsuario");
                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strUsuario");
                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strContrasena");
                entity.Property(e => e.IdRol).HasColumnName("intIdRol");
                entity.Property(e => e.IdPersonal).HasColumnName("intIdPersonal");
                entity.Property(e => e.IdCiudadano).HasColumnName("intIdCiudadano");
                entity.Property(e => e.Estado).HasColumnName("bitEstado");
                entity.Property(e => e.Activo).HasColumnName("bitActivo");
                entity.Property(e => e.Eliminado).HasColumnName("bitEliminado");
                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaRegistro");
                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaModificacion");
                entity.Property(e => e.FechaEliminacion)
                    .HasColumnType("datetime")
                    .HasColumnName("dtmFechaEliminacion");

                entity.HasOne(e => e.Rol)
                    .WithMany(r => r.Usuarios)
                    .HasForeignKey(e => e.IdRol)
                    .HasConstraintName("FK_USUARIOS_ROL");

                entity.HasOne(e => e.Personal)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(e => e.IdPersonal)
                    .HasConstraintName("FK_USUARIOS_PERSONAL");

                entity.HasOne(e => e.Ciudadano)
                    .WithMany(c => c.Usuarios)
                    .HasForeignKey(e => e.IdCiudadano)
                    .HasConstraintName("FK_USUARIOS_CIUDADANO");
            });


            modelBuilder.Entity<SP_SAB_DTS_RegistrarAlerta_Result>().HasNoKey().ToView(null);
            modelBuilder.Entity<SP_SAB_ListarAlerta_Result>().HasNoKey().ToView(null);
            modelBuilder.Entity<SP_SAB_DetalleAlerta_Result>().HasNoKey().ToView(null);
            modelBuilder.Entity<SP_SAB_ObtenerAlertaPorPersonal_Result>().HasNoKey().ToView(null);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
