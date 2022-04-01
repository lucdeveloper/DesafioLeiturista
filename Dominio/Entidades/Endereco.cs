namespace Domain.Entidades
{
    public  class Endereco : Base
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Cep { get; set; }

        public long Latitude { get; set; }

        public long Longitude { get; set; }

        public long ClienteID { get; set; }

        public Cliente Cliente { get; set; }
    }
}