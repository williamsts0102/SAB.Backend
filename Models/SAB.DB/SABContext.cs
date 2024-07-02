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
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SP_SAB_DTS_RegistrarAlerta_Result>().HasNoKey().ToView(null);
            modelBuilder.Entity<SP_SAB_ListarAlerta_Result>().HasNoKey().ToView(null);
            modelBuilder.Entity<SP_SAB_DetalleAlerta_Result>().HasNoKey().ToView(null);
            modelBuilder.Entity<SP_SAB_ObtenerAlertaPorPersonal_Result>().HasNoKey().ToView(null);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
