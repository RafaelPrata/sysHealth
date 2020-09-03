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
    public class TipoExameController : ParentController<TipoExame>
    {
        public TipoExameController(ILogger<TipoExameController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        [Route("{id}")]
        [Route("/TipoExame")]
        public IEnumerable<TipoExame> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] TipoExame objTipoExame)
        {
            Gravar(objTipoExame);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] TipoExame objTipoExame)
        {
            var update = Builders<TipoExame>.Update
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
