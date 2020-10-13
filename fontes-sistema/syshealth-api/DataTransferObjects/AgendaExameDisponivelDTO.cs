using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using syshealth_api.Domain;

namespace syshealth_api.DataTransferObjects
{
    public class AgendaExameDisponivelDTO
    {
        public string CodigoTipoExame { get; set; }
             
        public List<Horario> Horarios { get; set; }
    }
}
