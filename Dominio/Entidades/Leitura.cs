using System;

namespace Domain.Entidades
{
    public class Leitura : Base
    {
        public long LeituraAnterior { get; set; }

        public long ?LeituraAtual { get; set; }

        public DateTime DataLeitura { get; set; }

        public long LeituristaId { get; set; }

        public long ClienteId { get; set; }

        public long OcorrenciaId { get; set; }

        public Leiturista Leiturista { get; set; }

        public Cliente Cliente { get; set; }

        public Ocorrencia Ocorrencia { get; set; }

        public Leitura()
        {
            DataLeitura = DateTime.Now;
            
        }
    }
}
