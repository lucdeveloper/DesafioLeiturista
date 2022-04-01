using System.Collections.Generic;

namespace Domain.Entidades
{
    public  class Ocorrencia : Base
    {
        public string Descricao { get; set; }

        public bool PermiteLeitura { get; set; }

        public decimal Valor { get; set; }

        public ICollection<Leitura> Leituras { get; set; }
    }
}