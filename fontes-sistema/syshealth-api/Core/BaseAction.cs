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

namespace syshealth_api.Core
{
    public class BaseAction<T> where T : DomainBase
    {        
        private IMongoDbSettings _mongoDbSettings;

        protected IMongoDatabase db;

        public BaseAction(IMongoDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;

            db = new MongoClient(_mongoDbSettings.ConnectionString).GetDatabase(_mongoDbSettings.DatabaseName);
        }

        public IMongoCollection<T> GetDefaultCollection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public IMongoCollection<EspecificType> GetCollection<EspecificType>() where EspecificType : DomainBase
        {
            return db.GetCollection<EspecificType>(typeof(EspecificType).Name);
        }

        public IEnumerable<T> Listar(string id = null)
        {
            return id is null ? GetDefaultCollection().Find(_ => true).ToList() :
                                GetDefaultCollection().Find(x => x._id == new ObjectId(id)).ToList();
        }

        public void Gravar(T obj)
        {
            GetDefaultCollection().InsertOne(obj);
        }

        public UpdateResult Atualizar(double codigo, UpdateDefinition<T> update)
        {
            return GetDefaultCollection().UpdateOne(x => x.Codigo == codigo, update);
        }

        public void Deletar(string id)
        {
            GetDefaultCollection().DeleteOne(x => x._id == new ObjectId(id));
        }


    }
}
