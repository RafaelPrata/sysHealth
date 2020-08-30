using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    public class TipoLeito : DomainBase
    {
        public double Codigo { get; set; }

        public string Descricao { get; set; }
    }
}
