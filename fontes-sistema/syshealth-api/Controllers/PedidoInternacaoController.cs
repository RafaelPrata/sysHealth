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
        public PedidoInternacaoDTO Get(double codigo)
        {
            var pedidoInternacao = this.Action.Listar<PedidoInternacao>(codigo).FirstOrDefault();

            var paciente = this.Action.Listar<Paciente>(pedidoInternacao.CodigoPaciente).FirstOrDefault();

            return new PedidoInternacaoDTO
            {
                Codigo = pedidoInternacao.Codigo,

                NomeMedico = pedidoInternacao.MedicoSolicitante,

                CodigoClassificacao = pedidoInternacao.Classificacao,

                Motivo = pedidoInternacao.Motivo,

                Paciente = new PacienteDTO
                {
                    Cpf = paciente.NumeroCpf,
                    DataNascimento = paciente.DataNascimento.ToShortDateString(),
                    EstadoCivil = paciente.EstadoCivil,
                    Nome = paciente.Nome,
                    NomeMae = paciente.NomeMae,
                    NumeroSus = paciente.NumeroSus,
                    Rg = paciente.NumeroRg,
                    Sexo = paciente.Sexo,
                    Endereco = new EnderecoPaciente
                    {
                        Bairro = paciente.Endereco.Bairro,
                        Cep = paciente.Endereco.Cep,
                        Cidade = paciente.Endereco.Cidade,
                        Complemento = paciente.Endereco.Complemento,
                        Logradouro = paciente.Endereco.Logradouro,
                        Numero = paciente.Endereco.Numero,
                        Uf = paciente.Endereco.Uf
                    }
                }
            };

        }

        [HttpGet]
        [Route("/PedidoInternacao")]
        public IEnumerable<PedidoInternacao> Get()
        {
            return this.Action.Listar<PedidoInternacao>();            
        }

        [HttpGet]
        [Route("/PedidoInternacao/Status")]
        public IEnumerable<StatusPedidoInternacao> GetListaStatusPedidoInternacao()
        {
            return this.Action.GetCollection<StatusPedidoInternacao>().Find(_ => true).ToList();
        }

        [HttpGet]
        [Route("/PedidoInternacao/classificacao")]
        public IEnumerable<Classificacao> GetListaClassificacaoPedidoInternacao()
        {
            return this.Action.GetCollection<Classificacao>().Find(_ => true).ToList();
        }

        [HttpPost]
        public PedidoInternacao Post([FromBody] PedidoInternacaoDTO objPedidoInternacao)
        {
            return Action.GravarPedidoInternacao(objPedidoInternacao);
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
