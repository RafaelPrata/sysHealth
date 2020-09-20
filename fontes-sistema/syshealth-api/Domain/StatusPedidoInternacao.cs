using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    [BsonIgnoreExtraElements]
    public class StatusPedidoInternacao : DomainBase
    {
        public string Descricao { get; set; }
    }
}
