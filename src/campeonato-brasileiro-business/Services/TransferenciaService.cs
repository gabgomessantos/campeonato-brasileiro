using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Services
{
    public class TransferenciaService : BaseService, ITransferenciaService
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly IJogadorRepository _jogadorRepository;
        private readonly ITimeRepository _timeRepository;

        public TransferenciaService(INotificador notificador,
            ITransferenciaRepository transferenciaRepository,
            IJogadorRepository jogadorRepository,
            ITimeRepository timeRepository
            ) : base(notificador)
        {
            _transferenciaRepository = transferenciaRepository;
            _jogadorRepository = jogadorRepository;
            _timeRepository = timeRepository;
        }

        public async Task<IEnumerable<Transferencia>> ObterTransferenciasJogadorTime()
        {
            return await _transferenciaRepository.ObterTransferenciasJogadorTime();
        }

        public async Task<Transferencia> ObterTransferenciaJogadorTime(Guid id)
        {
            return await _transferenciaRepository.ObterTransferenciaJogadorTime(id);
        }

        public async Task Incluir(Transferencia transferencia)
        {
            if(Validacao(transferencia))
                await _transferenciaRepository.Incluir(transferencia);
        }

        public async Task Alterar(Transferencia transferencia)
        {
            if (Validacao(transferencia))
                await _transferenciaRepository.Alterar(transferencia);
        }

        public async Task Excluir(Guid id)
        {
            await _transferenciaRepository.Excluir(id);
        }

        public void Dispose()
        {
            _transferenciaRepository?.Dispose();
        }

        private bool Validacao(Transferencia transferencia)
        {
            bool isValid = true;

            if (_timeRepository.ObterPorId(transferencia.TimeOrigemId).Result == null)
            {
                Notificar("O time origem informado não existe.");
                isValid = false;
            }
            if (_timeRepository.ObterPorId(transferencia.TimeDestinoId).Result == null)
            {
                Notificar("O time destino informado não existe.");
                isValid = false;
            }
            if (_jogadorRepository.ObterPorId(transferencia.JogadorId).Result == null)
            {
                Notificar("O jogador informado não existe.");
                isValid = false;
            }

            return isValid;
        }
    }
}
