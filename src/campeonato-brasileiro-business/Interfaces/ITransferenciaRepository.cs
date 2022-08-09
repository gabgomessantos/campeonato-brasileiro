using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface ITransferenciaRepository : IRepository<Transferencia>
    {
        Task<IEnumerable<Transferencia>> ObterTransferenciasJogadorTime();

        Task<Transferencia> ObterTransferenciaJogadorTime(Guid id);
    }
}
