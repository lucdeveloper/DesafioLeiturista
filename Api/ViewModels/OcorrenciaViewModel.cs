using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class OcorrenciaViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool PermiteLeitura { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
    }
}
