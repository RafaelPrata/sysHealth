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
    public class LeitoController : ParentController<Leito>
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
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] Leito objLeito)
        {
            Gravar(objLeito);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] Leito objLeito)
        {
            var update = Builders<Leito>.Update
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
