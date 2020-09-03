using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using syshealth_api.Data;
using syshealth_api.Domain;

namespace syshealth_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoLeitoController : ParentController<TipoLeito>
    {
        public TipoLeitoController(ILogger<TipoLeitoController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        [Route("{id}")]
        [Route("/TipoLeito")]
        public IEnumerable<TipoLeito> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] TipoLeito objTipoLeito)
        {
            Gravar(objTipoLeito);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] TipoLeito objTipoLeito)
        {
            var update = Builders<TipoLeito>.Update
                .Set("xxxxxxxx", 123);

            Atualizar(id, update);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Deletar(id);
        }
    }
}
