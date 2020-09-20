using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    [BsonIgnoreExtraElements]
    public class Medico : DomainBase
    {
        public string Nome { get; set; }

        public string CRM { get; set; }

        public double CodigoEspecialidade { get; set; }
    }
}
