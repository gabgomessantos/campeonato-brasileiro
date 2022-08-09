using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface IJogadorService : IDisposable
    {
        Task<List<Jogador>> ObterJogadoresTime();

        Task<Jogador> ObterJogadorTimeTransferencias(Guid id);

        Task Incluir(Jogador jogador);

        Task Alterar(Jogador jogador);

        Task Excluir(Guid id);
    }
}
