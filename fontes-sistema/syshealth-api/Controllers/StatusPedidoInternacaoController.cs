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
    public class StatusPedidoInternacaoController : ParentController<StatusPedidoInternacao>
    {        
        public StatusPedidoInternacaoController(ILogger<StatusPedidoInternacaoController> logger, IMongoDbSettings mongoDbSettings) : 
            base(logger, mongoDbSettings)
        {            
            
        }

        [HttpGet]
        [Route("{id}")]
        [Route("/StatusPedidoInternacao")]
        public IEnumerable<StatusPedidoInternacao> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] StatusPedidoInternacao objStatusPedidoInternacaoController)
        {
            Gravar(objStatusPedidoInternacaoController);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] StatusPedidoInternacao objStatusPedidoInternacaoController)
        {
            var update = Builders<StatusPedidoInternacao>.Update
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
