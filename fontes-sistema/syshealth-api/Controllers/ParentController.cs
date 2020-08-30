using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using syshealth_api.Data;
using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Controllers
{
    public abstract class ParentController<T> : ControllerBase where T : DomainBase
    {
        private readonly ILogger<ControllerBase> _logger;

        private IMongoDbSettings _mongoDbSettings;

        public ParentController(ILogger<ControllerBase> logger, IMongoDbSettings mongoDbSettings)
        {
            _logger = logger;

            _mongoDbSettings = mongoDbSettings;
        }

        public IMongoCollection<T> GetCollection()
        {
            var db = new MongoClient(_mongoDbSettings.ConnectionString).GetDatabase(_mongoDbSettings.DatabaseName);

            return db.GetCollection<T>(typeof(T).Name);
        }

    }
}
