using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
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

        public IMongoDatabase db;

        public ParentController(ILogger<ControllerBase> logger, IMongoDbSettings mongoDbSettings)
        {
            _logger = logger;

            _mongoDbSettings = mongoDbSettings;

            db = new MongoClient(_mongoDbSettings.ConnectionString).GetDatabase(_mongoDbSettings.DatabaseName);
        }

        public IMongoCollection<T> GetDefaultCollection()
        {                        
            return db.GetCollection<T>(typeof(T).Name);
        }

        public IEnumerable<T> Listar(string id) //where T : DomainBase
        {
            return id is null ? GetDefaultCollection().Find(_ => true).ToList() :
                                GetDefaultCollection().Find(x => x._id == new ObjectId(id)).ToList();
        }

        public void Gravar(T obj)
        {
            GetDefaultCollection().InsertOne(obj);
        }

        public UpdateResult Atualizar(string id, UpdateDefinition<T> update)
        {
            return GetDefaultCollection().UpdateOne(x => x._id == new ObjectId(id), update);
        }

        public void Deletar(string id)
        {
            GetDefaultCollection().DeleteOne(x => x._id == new ObjectId(id));
        }

    }
}
