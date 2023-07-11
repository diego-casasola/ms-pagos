using Infraestructure.Pagos.EF.ReadModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Pagos.EF.Config.ReadConfig
{
    internal class PagoReadConfig : IEntityTypeConfiguration<PagoReadModel>
    {
        public void Configure(EntityTypeBuilder<PagoReadModel> builder)
        {
            builder.ToTable("pago");
            builder.HasKey(x => x.IdPago);
            builder.Property(x => x.IdPago).HasColumnName("idPago").IsRequired();
            builder.Property(x=> x.ProyectoId).HasColumnName("proyectoId").IsRequired();
            builder.Property(x => x.Monto).HasColumnName("monto").IsRequired();
            builder.Property(x => x.Estado).HasColumnName("estado").IsRequired();
        }
    }
}
