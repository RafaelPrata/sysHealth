using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    public class Especialidade : DomainBase
    {        
        public string Descricao { get; set; }

        public double Codigo { get; set; }
    }
}
