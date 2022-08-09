using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Services
{
    public class TorneioService : BaseService, ITorneioService
    {
        private readonly ITorneioRepository _torneioRepository;
        private readonly IPartidaRepository _partidaRepository;

        public TorneioService(
            INotificador notificador,
            ITorneioRepository torneioRepository,
            IPartidaRepository partidaRepository
            ) : base(notificador)
        {
            _torneioRepository = torneioRepository;
            _partidaRepository = partidaRepository;
        }

        public async Task<List<Torneio>> ObterTodos()
        {
            return await _torneioRepository.ObterTodos();
        }

        public async Task<Torneio> ObterPorId(Guid id)
        {
            return await _torneioRepository.ObterPorId(id);
        }

        public async Task<Torneio> ObterPorNome(string nome)
        {
            var torneio = await _torneioRepository.Buscar(x => x.Nome == nome);
            return torneio?.FirstOrDefault();
        }

        public async Task<Torneio> ObterTorneioTimes(Guid id)
        {
            return await _torneioRepository.ObterTorneioTimes(id);
        }

        public async Task<Torneio> ObterTorneioTimesPartidas(Guid id)
        {
            var torneio = await _torneioRepository.ObterTorneioTimesPartidas(id);

            if (torneio != null)
                torneio.Partidas = await _partidaRepository.ObterPartidasPorTorneio(id);

            return torneio;
        }

        public async Task Incluir(Torneio torneio)
        {
            if (_torneioRepository.Buscar(x => x.Nome == torneio.Nome).Result.Any())
            {
                Notificar("O torneio " + torneio.Nome + " já está cadastrado.");
                return;
            }
            
            await _torneioRepository.Incluir(torneio);
        }

        public async Task Alterar(Torneio torneio)
        {
            if (_torneioRepository.Buscar(t => t.Nome == torneio.Nome && t.Id != torneio.Id).Result.Any())
            {
                Notificar("O torneio " + torneio.Nome + " já está cadastrado.");
                return;
            }

            await _torneioRepository.Alterar(torneio);
        }

        public async Task Excluir(Guid id)
        {
            await _torneioRepository.Excluir(id);
        }

        public void Dispose()
        {
            _torneioRepository?.Dispose();
        }
    }
}
