using System;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class AdicionaLeituraViewModel
    {
        public long Id { get; set; }

        public long LeituraAnterior { get; set; }

        public long ?LeituraAtual { get; set; }

        public long LeituristaId { get; set; }

        public long ClienteId { get; set; }

        public long OcorrenciaId { get; set; }
    }
}