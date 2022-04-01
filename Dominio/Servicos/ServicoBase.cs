using Domain.Entidades;
using Domain.Interfaces;
using Domain.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Servicos
{
    public abstract class ServicoBase
    { 
    
        private readonly INotificacao _notificador;

    protected ServicoBase(INotificacao notificador)
    {
        _notificador = notificador;
    }

    protected void Notificar(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notificar(error.ErrorMessage);
        }
    }

    protected void Notificar(string mensagem)
    {
        _notificador.Handle(new Notificacao(mensagem));
    }

    protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Base
    {
        var validator = validacao.Validate(entidade);

        if (validator.IsValid) return true;

        Notificar(validator);

        return false;
    }
  }
}
