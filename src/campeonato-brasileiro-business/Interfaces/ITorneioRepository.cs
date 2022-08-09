using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface ITorneioRepository : IRepository<Torneio>
    {
        Task<Torneio> ObterTorneioTimes(Guid id);

        Task<Torneio> ObterTorneioTimesPartidas(Guid id);
    }
}
