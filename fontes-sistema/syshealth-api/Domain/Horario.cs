using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    [BsonIgnoreExtraElements]
    public class Horario : DomainBase
    {
        public string HoraInicial { get; set; }

        public string HoraFinal { get; set; }        
    }
}
