

using Infraestructure.Pagos.EF.Config.ReadConfig;
using Infraestructure.Pagos.EF.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Pagos.EF.Context
{
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<PagoReadModel> Pagos { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<PagoReadModel>(new PagoReadConfig());
        }
    }
}
