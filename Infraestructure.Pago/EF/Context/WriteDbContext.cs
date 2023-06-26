using Domain.Pagos.Model.Pago;
using Infraestructure.Pagos.EF.Config.WriteConfig;
using Infraestructure.Pagos.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Pagos.EF.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Pago> Pagos { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PagoWriteConfig());
        }
    }
}
