using FluentValidation;

namespace Domain.Entidades.Validacao
{
    public class ValidacaoCargo : AbstractValidator<Cargo>
    {
        public ValidacaoCargo()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(10, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}