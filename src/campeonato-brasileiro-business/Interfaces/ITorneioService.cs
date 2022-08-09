using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface ITorneioService : IDisposable
    {
        Task<List<Torneio>> ObterTodos();

        Task<Torneio> ObterPorId(Guid id);

        Task<Torneio> ObterPorNome(string nome);

        Task<Torneio> ObterTorneioTimes(Guid id);

        Task<Torneio> ObterTorneioTimesPartidas(Guid id);

        Task Incluir(Torneio torneio);

        Task Alterar(Torneio torneio);

        Task Excluir(Guid id);
    }
}
