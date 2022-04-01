using FluentValidation;

namespace Domain.Entidades.Validacao
{
    public class ValidacaoLeiturista : AbstractValidator<Leiturista>
    {
        public ValidacaoLeiturista()
        {
            RuleFor(c => c.Matricula)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
                
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(10, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Ativo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}