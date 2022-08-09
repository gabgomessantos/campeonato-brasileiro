using campeonato_brasileiro_business.Models;
using Microsoft.EntityFrameworkCore;

namespace campeonato_brasileiro_data.Contexts
{
    public class CampeonatoBrasileiroDbContext : DbContext
    {
        public CampeonatoBrasileiroDbContext(DbContextOptions<CampeonatoBrasileiroDbContext> options) : base(options) {}

        public DbSet<Torneio> Torneios { get; set; }
        public DbSet<Partida> Partidas { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Transferencia> Transferencias { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CampeonatoBrasileiroDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
