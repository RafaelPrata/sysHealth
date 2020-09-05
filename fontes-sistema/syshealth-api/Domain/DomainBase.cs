using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    public class DomainBase
    {
        public ObjectId _id { get; set; }

        public int Codigo { get; set; }
    }
}
