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
    public class BaseAction
    {
        private IMongoDbSettings _mongoDbSettings;

        protected IMongoDatabase db;

        public BaseAction(IMongoDbSettings mongoDbSettings)
        {
            _mongoDbSettings = mongoDbSettings;

            db = new MongoClient(_mongoDbSettings.ConnectionString).GetDatabase(_mongoDbSettings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>() where T : DomainBase
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public IEnumerable<T> Listar<T>(double? codigo = null) where T : DomainBase
        {
            var collection = db.GetCollection<T>(typeof(T).Name);

            return codigo is null ? collection.Find(_ => true).ToList() :
                                    collection.Find(x => x.Codigo == codigo).ToList();
        }

        public T Gravar<T>(T obj) where T : DomainBase
        {
            var collection = db.GetCollection<T>(typeof(T).Name);

            obj.Codigo = collection.EstimatedDocumentCount() + 1;

            collection.InsertOne(obj);

            return obj;
        }

        public UpdateResult Atualizar<T>(double codigo, UpdateDefinition<T> update) where T : DomainBase
        {
            var collection = db.GetCollection<T>(typeof(T).Name);

            return collection.UpdateOne(x => x.Codigo == codigo, update);
        }

        public void Deletar<T>(double codigo) where T : DomainBase
        {
            var collection = db.GetCollection<T>(typeof(T).Name);

            collection.DeleteOne(x => x.Codigo == codigo);
        }


    }
}
