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
        [Route("{codigo}")]
        [Route("/Leito")]
        public IEnumerable<Leito> Get(double? codigo)
        {
            return this.Action.Listar<Leito>(codigo);
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
                                            .Set("Local", objLeito.Local)
                                            .Set("CodigoStatusLeito", objLeito.CodigoStatusLeito)
                                            .Set("CodigoTipoLeito", objLeito.CodigoTipoLeito);

            this.Action.Atualizar(codigo, update);
        }

        [HttpDelete("{codigo}")]
        public void Delete(double codigo)
        {
            this.Action.Deletar<Leito>(codigo);
        }
    }
}
