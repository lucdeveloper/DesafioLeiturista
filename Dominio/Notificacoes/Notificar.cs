using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Notificacoes
{
    public class Notificar : INotificacao
    {
        private readonly List<Notificacao> _listaNotificacao;

        public Notificar()
        {
            _listaNotificacao = new List<Notificacao>();
        }
        
        public void Handle(Notificacao notificacao)
        {
            _listaNotificacao.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _listaNotificacao;
        }

        public bool TemNotificacao()
        {
            return _listaNotificacao.Any();
        }
    }
}
