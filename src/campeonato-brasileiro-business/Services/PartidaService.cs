using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Services
{
    public class PartidaService : BaseService, IPartidaService
    {
        private readonly IPartidaRepository _partidaRepository;
        private readonly ITorneioRepository _torneioRepository;
        private readonly ITimeRepository _timeRepository;
        private readonly IEventoRepository _eventoRepository;

        public PartidaService(INotificador notificador,
            IPartidaRepository partidaRepository,
            ITorneioRepository torneioRepository,
            ITimeRepository timeRepository,
            IEventoRepository eventoRepository
            ) : base(notificador)
        {
            _partidaRepository = partidaRepository;
            _torneioRepository = torneioRepository;
            _timeRepository = timeRepository;
            _eventoRepository = eventoRepository;
        }

        public async Task<IEnumerable<Partida>> ObterPartidasTorneioTime()
        {
            return await _partidaRepository.ObterPartidasTorneioTime();
        }

        public async Task<Partida> ObterPartidaTorneioTime(Guid id)
        {
            return await _partidaRepository.ObterPartidaTorneioTime(id);
        }

        public async Task<Partida> ObterPartidaTorneioTimeEventos(Guid id)
        {
            return await _partidaRepository.ObterPartidaTorneioTimeEventos(id);
        }

        public async Task Incluir(Partida partida)
        {
            if (Validacao(partida))
                await _partidaRepository.Incluir(partida);
        }

        public async Task IncluirMuitos(List<Partida> partidas)
        {
            foreach (var partida in partidas)
            {
                if (!Validacao(partida))
                    partidas.Remove(partida);
            }

            await _partidaRepository.ExcluirMuitos(_partidaRepository.ObterTodos().Result);
            await _partidaRepository.IncluirMuitos(partidas);
        }

        public async Task IncluirEvento(Evento evento)
        {
            if(Validacao(evento))
                await _eventoRepository.Incluir(evento);
        }

        public async Task ExcluirEvento(Guid id)
        {
            await _eventoRepository.Excluir(id);
        }

        public async Task Alterar(Partida partida)
        {
            if (Validacao(partida))
                await _partidaRepository.Alterar(partida);
        }

        public async Task Excluir(Guid id)
        {
            await _partidaRepository.Excluir(id);
        }

        public void Dispose()
        {
            _partidaRepository?.Dispose();
        }

        private bool Validacao(Partida partida)
        {
            bool isValid = true;

            if (_timeRepository.ObterPorId(partida.TimeMandanteId).Result == null)
            {
                Notificar("O time mandante informado não existe.");
                isValid = false;
            }
            if (_timeRepository.ObterPorId(partida.TimeVisitanteId).Result == null)
            {
                Notificar("O time visitante informado não existe.");
                isValid = false;
            }
            if (_torneioRepository.ObterPorId(partida.TorneioId).Result == null)
            {
                Notificar("O torneiro informado não existe.");
                isValid = false;
            }

            return isValid;
        }

        private bool Validacao(Evento evento)
        {
            bool isValid = true;

            if (_partidaRepository.ObterPorId(evento.PartidaId).Result == null)
            {
                Notificar("A partida informada não existe.");
                isValid = false;
            }

            return isValid;
        }
    }
}
