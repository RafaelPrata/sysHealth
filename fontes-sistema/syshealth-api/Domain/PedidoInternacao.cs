using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    public class PedidoInternacao : DomainBase
    {
        public double? CodigoLeito { get; set; }
        public double CodigoPaciente { get; set; }
        public DateTime DataHoraSolicitacao { get; set; }
        public string Motivo { get; set; }
        public double Classificacao { get; set; }
        public string MedicoSolicitante { get; set; }
        public DateTime? DataInternacao { get; set; }
        public DateTime? DataAlta { get; set; }
        public double? CodigoStatusPedidoInternacao { get; set; }
        public double CodigoUsuario { get; set; }

        public double CodigoTipoLeito { get; set; }
    }
}
