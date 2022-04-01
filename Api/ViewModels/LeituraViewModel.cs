using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class LeituraViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long LeituraAnterior { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long LeituraAtual { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataLeitura { get; set; }

        public LeituristaViewModel Leiturista { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public OcorrenciaViewModel Ocorrencia { get; set; }

    }
}