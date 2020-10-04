using MongoDB.Bson.Serialization.Attributes;

namespace syshealth_api.Domain
{
    [BsonIgnoreExtraElements]
    public class Classificacao : DomainBase
    {
        public string Descricao { get; set; }
    }
}
