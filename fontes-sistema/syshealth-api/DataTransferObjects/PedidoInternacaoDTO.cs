using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.DataTransferObjects
{
    public class PedidoInternacaoDTO
    {
        public string NomeMedicoSolicitante { get; set; }

        public double Classificacao { get; set; }

        public string Motivo { get; set; }

        public double CodigoUsuario { get; set; }

        public double CodigoTipoLeito { get; set; }

        public PacienteDTO Paciente { get; set; }
    }
}
