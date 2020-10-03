using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.DataTransferObjects
{
    public class PedidoInternacaoDTO
    {
        public double Codigo { get; set; }

        public string NomeMedico { get; set; }

        public double CodigoClassificacao { get; set; }

        public string Motivo { get; set; }

        public double CodigoUsuario { get; set; }

        public double CodigoTipoLeito { get; set; }

        public PacienteDTO Paciente { get; set; }
    }
}
