using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using syshealth_api.Core;
using syshealth_api.Data;
using syshealth_api.Domain;

namespace syshealth_api.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class LeitoController : ParentController<Leito, LeitoAction>
    {
        public LeitoController(ILogger<LeitoController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        [Route("{id}")]
        [Route("/Leito")]
        public IEnumerable<Leito> Get(string id)
        {
            return this.Action.Listar(id);
        }

        [HttpGet]
        [Route("/Leito/StatusLeito")]
        public IEnumerable<StatusLeito> GetStatusLeito()
        {
            return this.Action.GetCollection<StatusLeito>().Find(_ => true).ToList();
        }

        [HttpGet]
        [Route("/Leito/TipoLeito")]
        public IEnumerable<TipoLeito> GetTipoLeito()
        {
            return this.Action.GetCollection<TipoLeito>().Find(_ => true).ToList();
        }

        [HttpPost]
        public void Post([FromBody] Leito objLeito)
        {
            this.Action.Gravar(objLeito);
        }

        [HttpPut("{codigo}")]
        public void Update(double codigo, [FromBody] Leito objLeito)
        {
            var update = Builders<Leito>.Update
                .Set("xxxxxxxx", 123);

            this.Action.Atualizar(codigo, update);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.Action.Deletar(id);
        }
    }
}
