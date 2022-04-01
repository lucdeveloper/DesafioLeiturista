using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Cliente : Base
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public Endereco Endereco { get; set; }

        public ICollection<Leitura> Leituras { get; set; }
    }
}