using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    [BsonIgnoreExtraElements]
    public class Leito : DomainBase
    {

        public string Numero { get; set; }

        public string Local { get; set; }

        public double CodigoStatusLeito { get; set; }

        public double CodigoTipoLeito { get; set; }
    }
}
