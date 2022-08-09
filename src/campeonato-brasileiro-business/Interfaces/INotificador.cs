using campeonato_brasileiro_business.Notificacoes;

namespace campeonato_brasileiro_business.Interfaces
{
    public interface INotificador
    {
        List<Notificacao> ObterNotificacoes();
        bool TemNotificacao();
        void Handle(Notificacao notificacao);
    }
}
