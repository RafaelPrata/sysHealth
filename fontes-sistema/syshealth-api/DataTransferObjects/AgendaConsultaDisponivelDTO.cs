using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using syshealth_api.Domain;

namespace syshealth_api.DataTransferObjects
{
    public class AgendaConsultaDisponivelDTO
    {
        public double CodigoMedico { get; set; }

        public string NomeMedico { get; set; }

        public string Crm { get; set; }

        public DateTime Data { get; set; }

        public List<Horario> Horarios { get; set; }
    }
}
