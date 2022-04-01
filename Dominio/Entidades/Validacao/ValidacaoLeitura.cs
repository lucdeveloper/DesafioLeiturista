using FluentValidation;

namespace Domain.Entidades.Validacao
{
    public class ValidacaoLeitura : AbstractValidator<Leitura>
    {
        public ValidacaoLeitura()
        {
            RuleFor(c => c.ClienteId)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.LeituristaId)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.OcorrenciaId)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
