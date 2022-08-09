using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface IJogadorRepository : IRepository<Jogador>
    {
        Task<List<Jogador>> ObterJogadoresTime();

        Task<Jogador> ObterJogadorTimeTransferencias(Guid id);
    }
}
