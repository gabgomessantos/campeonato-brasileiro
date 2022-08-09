using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface ITimeService : IDisposable
    {
        Task<List<Time>> ObterTodos();

        Task<Time> ObterPorId(Guid id);

        Task<Time> ObterTimeJogadores(Guid id);

        Task Incluir(Time time);

        Task IncluirMuitos(List<Time> times);

        Task Alterar(Time time);

        Task Excluir(Guid id);
    }
}
