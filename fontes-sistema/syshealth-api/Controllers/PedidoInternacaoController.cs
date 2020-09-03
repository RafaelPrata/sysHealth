using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using syshealth_api.Data;
using syshealth_api.Domain;

namespace syshealth_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoInternacaoController : ParentController<PedidoInternacao>
    {
        public PedidoInternacaoController(ILogger<PedidoInternacaoController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        [Route("{id}")]
        [Route("/PedidoInternacao")]
        public IEnumerable<PedidoInternacao> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] PedidoInternacao objPedidoInternacao)
        {
            Gravar(objPedidoInternacao);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] PedidoInternacao objPedidoInternacao)
        {
            var update = Builders<PedidoInternacao>.Update
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
