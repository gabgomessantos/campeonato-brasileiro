using campeonato_brasileiro_business.Interfaces;
using campeonato_brasileiro_business.Notificacoes;

namespace campeonato_brasileiro_business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
