using campeonato_brasileiro_business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campeonato_brasileiro_data.Mappings
{
    public class TransferenciaMapping : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Data)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(t => t.Valor)
                .IsRequired();

            builder.Property(t => t.TimeOrigemId)
                .IsRequired();

            builder.Property(t => t.TimeDestinoId)
                .IsRequired();

            builder.ToTable("Transferencias");
        }
    }
}
