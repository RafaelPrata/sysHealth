using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    public class Paciente : DomainBase
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
        public string NomeMae { get; set; }
        public string NumeroCpf { get; set; }
        public string NumeroRg { get; set; }
        public string NumeroSus { get; set; }
        public string Endereco { get; set; }
        public string EstadoCivil { get; set; }

    }
}
