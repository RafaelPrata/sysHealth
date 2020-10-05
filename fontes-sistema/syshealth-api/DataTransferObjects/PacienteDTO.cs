using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.DataTransferObjects
{
    public class PacienteDTO
    {
        public string Nome { get; set; }

        public string Sexo { get; set; }

        public string DataNascimento { get; set; }

        public string EstadoCivil { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string NumeroSus { get; set; }

        public string NomeMae { get; set; }

        public EnderecoPaciente Endereco { get; set; }
    }
}
