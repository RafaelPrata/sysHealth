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
            var filterLeito = Builders<Leito>.Filter.And("{CodigoStatusLeito: 2}", "{CodigoTipoLeito: 11}");
            var updateLeito = Builders<Leito>.Update.Set("CodigoStatusLeito", 1);

            var leitoDisponivel = db.GetCollection<Leito>(typeof(Leito).Name).FindOneAndUpdate(filterLeito, updateLeito);

            if(leitoDisponivel != null)
            {
                objPedidoInternacao.CodigoLeito = leitoDisponivel.Codigo;
            }
            else
            {
                objPedidoInternacao.CodigoStatusPedidoInternacao = 1;
            }
            
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
