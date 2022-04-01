using Domain.Notificacoes;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface INotificacao
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}