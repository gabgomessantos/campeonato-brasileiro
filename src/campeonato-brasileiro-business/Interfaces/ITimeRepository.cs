using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface ITimeRepository : IRepository<Time>
    {
        Task<Time> ObterTimeJogadores(Guid id);

        Task<Time> ObterTimeJogadoresTorneios(Guid id);
    }
}
