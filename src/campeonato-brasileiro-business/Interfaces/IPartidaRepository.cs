using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface IPartidaRepository : IRepository<Partida>
    {
        Task<IEnumerable<Partida>> ObterPartidasTorneioTime();

        Task<Partida> ObterPartidaTorneioTime(Guid id);

        Task<Partida> ObterPartidaTorneioTimeEventos(Guid id);

        Task<IEnumerable<Partida>> ObterPartidasPorTorneio(Guid torneioId);

        Task ExcluirMuitos(List<Partida> partidas);
    }
}
