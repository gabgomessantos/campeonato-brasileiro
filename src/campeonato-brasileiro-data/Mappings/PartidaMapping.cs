using campeonato_brasileiro_business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campeonato_brasileiro_data.Mappings
{
    public class PartidaMapping : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.TimeMandanteId)
                .IsRequired();

            builder.Property(p => p.TimeVisitanteId)
                .IsRequired();

            /*-----------------*/
            builder.HasMany(p => p.Eventos)
                .WithOne(e => e.Partida)
                .HasForeignKey(e => e.PartidaId);

            builder.ToTable("Partidas");
        }
    }
}
