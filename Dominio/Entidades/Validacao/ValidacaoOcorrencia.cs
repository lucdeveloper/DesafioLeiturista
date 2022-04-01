using FluentValidation;

namespace Domain.Entidades.Validacao
{
    public class ValidacaoOcorrencia : AbstractValidator<Ocorrencia>
    {
        public ValidacaoOcorrencia()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.PermiteLeitura)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
             
            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}