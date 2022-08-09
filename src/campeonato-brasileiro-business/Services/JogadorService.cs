using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Services
{
    public class JogadorService : BaseService, IJogadorService
    {
        private readonly IJogadorRepository _jogadorRepository;
        private readonly ITimeRepository _timeRepository;

        public JogadorService(INotificador notificador,
            IJogadorRepository jogadorRepository,
            ITimeRepository timeRepository
            ) : base(notificador)
        {
            _jogadorRepository = jogadorRepository;
            _timeRepository = timeRepository;
        }

        public async Task<List<Jogador>> ObterJogadoresTime()
        {
            return await _jogadorRepository.ObterJogadoresTime();
        }

        public async Task<Jogador> ObterJogadorTimeTransferencias(Guid id)
        {
            return await _jogadorRepository.ObterJogadorTimeTransferencias(id);
        }

        public async Task Incluir(Jogador jogador)
        {
            if (Validacao(jogador))
                await _jogadorRepository.Incluir(jogador);
        }

        public async Task Alterar(Jogador jogador)
        {
            if (Validacao(jogador))
                await _jogadorRepository.Alterar(jogador);
        }

        public async Task Excluir(Guid id)
        {
            await _jogadorRepository.Excluir(id);
        }

        public void Dispose()
        {
            _jogadorRepository?.Dispose();
        }

        private bool Validacao(Jogador jogador)
        {
            bool isValid = true;

            if (_timeRepository.ObterPorId(jogador.TimeId).Result == null)
            {
                Notificar("O time informado não existe.");
                isValid = false;
            }

            return isValid;
        }
    }
}
