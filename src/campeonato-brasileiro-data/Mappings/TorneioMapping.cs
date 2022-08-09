using campeonato_brasileiro_business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campeonato_brasileiro_data.Mappings
{
    public class TorneioMapping : IEntityTypeConfiguration<Torneio>
    {
        public void Configure(EntityTypeBuilder<Torneio> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            /*-----------------*/
            builder.HasMany(t => t.Times)
                .WithMany(p => p.Torneios);

            builder.HasMany(t => t.Partidas)
                .WithOne(p => p.Torneio)
                .HasForeignKey(p => p.TorneioId);

            builder.ToTable("Torneios");
        }
    }
}
