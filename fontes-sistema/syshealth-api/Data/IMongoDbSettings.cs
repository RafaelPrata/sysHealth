using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Data
{
    public interface IMongoDbSettings
    {
        string DatabaseName { get; set; }

        string ConnectionString { get; set; }
    }
}
