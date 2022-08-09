using campeonato_brasileiro_business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campeonato_brasileiro_data.Mappings
{
    public class JogadorMapping : IEntityTypeConfiguration<Jogador>
    {
        public void Configure(EntityTypeBuilder<Jogador> builder)
        {
            builder.HasKey(j => j.Id);

            builder.Property(j => j.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(j => j.DataNascimento)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(j => j.Pais)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            /*-----------------*/
            builder.HasMany(j => j.Transferencias)
                .WithOne(t => t.Jogador)
                .HasForeignKey(t => t.JogadorId);

            builder.ToTable("Jogadores");
        }
    }
}
