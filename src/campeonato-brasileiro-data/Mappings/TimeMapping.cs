using campeonato_brasileiro_business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campeonato_brasileiro_data.Mappings
{
    public class TimeMapping : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(t => t.Localidade)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            /*-----------------*/
            builder.HasMany(t => t.Jogadores)
                .WithOne(j => j.Time)
                .HasForeignKey(j => j.TimeId);

            builder.HasMany(t => t.Transferencias)
                .WithOne(x => x.TimeOrigem)
                .HasForeignKey(x => x.TimeOrigemId);

            //builder.HasMany(t => t.Transferencias)
            //    .WithOne(x => x.TimeDestino)
            //    .HasForeignKey(x => x.TimeDestinoId);

            builder.HasMany(t => t.Partidas)
                .WithOne(p => p.TimeMandante)
                .HasForeignKey(p => p.TimeMandanteId);

            //builder.HasMany(t => t.Partidas)
            //    .WithOne(p => p.TimeVisitante)
            //    .HasForeignKey(p => p.TimeVisitanteId);

            builder.ToTable("Times");
        }
    }
}
