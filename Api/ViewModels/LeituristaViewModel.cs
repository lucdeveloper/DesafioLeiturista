using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class LeituristaViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long Matricula { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}
