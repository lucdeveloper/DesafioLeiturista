using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Leiturista : Base
    {
        public long Matricula { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public ICollection<Leitura> Leituras { get; set; }

    }
}