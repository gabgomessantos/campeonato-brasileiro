using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface ITransferenciaService : IDisposable
    {
        Task<IEnumerable<Transferencia>> ObterTransferenciasJogadorTime();

        Task<Transferencia> ObterTransferenciaJogadorTime(Guid id);

        Task Incluir(Transferencia transferencia);

        Task Alterar(Transferencia transferencia);

        Task Excluir(Guid id);
    }
}
