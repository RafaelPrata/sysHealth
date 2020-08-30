using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    public class Medico : DomainBase
    {
        public double Codigo { get; set; }

        public string Nome { get; set; }

        public string CRM { get; set; }

        public double CodigoEspecialidade { get; set; }
    }
}
