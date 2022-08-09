using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface IPartidaService : IDisposable
    {
        Task<IEnumerable<Partida>> ObterPartidasTorneioTime();

        Task<Partida> ObterPartidaTorneioTime(Guid id);

        Task<Partida> ObterPartidaTorneioTimeEventos(Guid id);

        Task Incluir(Partida partida);

        Task IncluirMuitos(List<Partida> partidas);

        Task IncluirEvento(Evento evento);

        Task ExcluirEvento(Guid id);

        Task Alterar(Partida partida);

        Task Excluir(Guid id);
    }
}
