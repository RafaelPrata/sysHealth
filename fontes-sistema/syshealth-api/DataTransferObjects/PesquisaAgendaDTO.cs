using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.DataTransferObjects
{
    public class PesquisaAgendaDTO
    {
        public int CodigoServico { get; set; }

        public int CodigoTipoAgenda { get; set; }

        public DateTime Data { get; set; }
    }
}
