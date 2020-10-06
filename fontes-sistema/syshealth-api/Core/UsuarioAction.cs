using MongoDB.Driver;
using syshealth_api.Data;
using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Core
{
    public class UsuarioAction : BaseAction
    {
        public UsuarioAction(IMongoDbSettings mongoDbSettings) : base(mongoDbSettings)
        {

        }

        public Usuario BuscarUsuario(string login, string senha)
        {
            var collection = db.GetCollection<Usuario>(typeof(Usuario).Name);

            return collection.Find(x => x.Login == login && x.Senha == senha).FirstOrDefault();
        }

        public List<Usuario> PesuisarUsuario(Usuario objUsuario)
        {
            var collection = db.GetCollection<Usuario>(typeof(Usuario).Name);

            var filterBuilder = Builders<Usuario>.Filter;

            var filters = new List<FilterDefinition<Usuario>>();

            if (objUsuario.CodigoPerfil != 0)
            {
                filters.Add(filterBuilder.Eq("CodigoPerfil", objUsuario.CodigoPerfil));
            }

            if (objUsuario.Nome != null)
            {
                filters.Add(filterBuilder.Where(x => x.Nome.Contains(objUsuario.Nome)));
            }

            if (objUsuario.Login != null)
            {
                filters.Add(filterBuilder.Where(x => x.Login.Contains(objUsuario.Login)));
            }

            var filter = filterBuilder.And(filters);

            return filters.Count > 0? collection.Find(filter).ToList(): 
                                      collection.Find(_ => true).ToList();
        }
    }
}
