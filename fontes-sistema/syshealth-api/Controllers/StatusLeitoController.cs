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
    public class StatusLeitoController : ParentController<StatusLeito>
    {        
        public StatusLeitoController(ILogger<StatusLeitoController> logger, IMongoDbSettings mongoDbSettings) : 
            base(logger, mongoDbSettings)
        {            
            
        }

        [HttpGet]
        [Route("{id}")]
        [Route("/StatusLeito")]
        public IEnumerable<StatusLeito> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] StatusLeito objStatusLeito)
        {
            Gravar(objStatusLeito);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] StatusLeito objStatusLeito)
        {
            var update = Builders<StatusLeito>.Update
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
