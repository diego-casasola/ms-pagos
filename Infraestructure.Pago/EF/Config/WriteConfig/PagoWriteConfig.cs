using Domain.Pagos.Model.Pago;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Pagos.EF.Config.WriteConfig
{
    internal class PagoWriteConfig : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("pago");

            builder.Property(x => x.Id).HasColumnName("idPago");
            builder.Property(x => x.ProyectoId).HasColumnName("proyectoId");
            builder.Property(x => x.Monto).HasColumnName("monto");
            builder.Property(x => x.Estado).HasColumnName("estado");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
