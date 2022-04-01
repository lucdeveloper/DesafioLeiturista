using Domain.Interfaces;
using Domain.Notificacoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Api.Controllers
{
    [ApiController]
    public abstract class ControllerConfig : ControllerBase
    {
        private readonly INotificacao _notificacao;

        public ControllerConfig(INotificacao notificacao)
        {
            _notificacao = notificacao;
        }

        protected bool OperacaoValida()
        {
            return !_notificacao.TemNotificacao();
        }

        protected ActionResult RetornoOperacao(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificacao.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                NotificarErrorModelInvalida(modelState);
            }
            return RetornoOperacao();
        }

        protected void NotificarErrorModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarError(errorMsg);
            }
        }

        protected void NotificarError(string mensagem)
        {
            _notificacao.Handle(new Notificacao(mensagem));
        }
    }
}
