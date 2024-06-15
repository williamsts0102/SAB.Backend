using Microsoft.EntityFrameworkCore;

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
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
