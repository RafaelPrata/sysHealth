namespace syshealth_api.Domain
{
    public class EnderecoPaciente
    {
        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public double Numero { get; set; }

        public string Complemento { get; set; }
        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

    }
}