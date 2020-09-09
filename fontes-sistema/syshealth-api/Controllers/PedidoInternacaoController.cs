using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using syshealth_api.Core;
using syshealth_api.Data;
using syshealth_api.DataTransferObjects;
using syshealth_api.Domain;
using syshealth_api.Enums;

namespace syshealth_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoInternacaoController : ParentController<PedidoInternacao, PedidoInternacaoAction>
    {
        public PedidoInternacaoController(ILogger<PedidoInternacaoController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        [Route("{codigo}")]
        [Route("/PedidoInternacao")]
        public IEnumerable<PedidoInternacao> Get(double? codigo)
        {
            return this.Action.Listar<PedidoInternacao>(codigo);
        }

        [HttpGet]
        [Route("/PedidoInternacao/Status")]
        public IEnumerable<StatusPedidoInternacao> GetListaStatusPedidoInternacao()
        {
            return this.Action.GetCollection<StatusPedidoInternacao>().Find(_ => true).ToList();
        }

        [HttpPost]
        public void Post([FromBody] PedidoInternacaoDTO objPedidoInternacao)
        {
            Action.GravarPedidoInternacao(objPedidoInternacao);
        }

        [HttpPut("{id}")]
        public void Update(double codigo, [FromBody] PedidoInternacao objPedidoInternacao)
        {
            var update = Builders<PedidoInternacao>.Update
                .Set("xxxxxxxx", 123);

            this.Action.Atualizar(codigo, update);
        }


        [HttpPut()]
        [Route("/PedidoInternacao/{codigo}/AltaPaciente")]
        public void AltaPaciente(double codigo)
        {
            var update = Builders<PedidoInternacao>.Update
                .Set("DataAlta", DateTime.Now)
                .Set("CodigoStatusPedidoInternacao", (int)EnStatusPedidoInternacao.Concluido);

            this.Action.Atualizar(codigo, update);
        }

        [HttpDelete("{codigo}")]
        public void Delete(double codigo)
        {
            this.Action.Deletar<PedidoInternacao>(codigo);
        }
    }
}
