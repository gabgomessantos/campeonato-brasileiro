using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Models;

namespace campeonato_brasileiro_business.Services
{
    public class TimeService : BaseService, ITimeService
    {
        private readonly ITimeRepository _timeRepository;

        public TimeService(
            INotificador notificador, 
            ITimeRepository timeRepository
            ) : base(notificador)
        {
            _timeRepository = timeRepository;
        }

        public async Task<List<Time>> ObterTodos()
        {
            return await _timeRepository.ObterTodos();
        }

        public async Task<Time> ObterPorId(Guid id)
        {
            return await _timeRepository.ObterPorId(id);
        }

        public async Task<Time> ObterTimeJogadores(Guid id)
        {
            return await _timeRepository.ObterTimeJogadores(id);
        }

        public async Task Incluir(Time time)
        {
            if (_timeRepository.Buscar(t => t.Nome == time.Nome).Result.Any())
            {
                Notificar("O time "+ time.Nome + " já está cadastrado.");
                return;
            }

            await _timeRepository.Incluir(time);
        }

        public async Task IncluirMuitos(List<Time> times)
        {
            await _timeRepository.IncluirMuitos(times);
        }

        public async Task Alterar(Time time)
        {
            if (_timeRepository.Buscar(t => t.Nome == time.Nome && t.Id != time.Id).Result.Any())
            {
                Notificar("O time " + time.Nome + " já está cadastrado.");
                return;
            }

            await _timeRepository.Alterar(time);
        }

        public async Task Excluir(Guid id)
        {
            await _timeRepository.Excluir(id);
        }

        public void Dispose()
        {
            _timeRepository?.Dispose();
        }
    }
}
