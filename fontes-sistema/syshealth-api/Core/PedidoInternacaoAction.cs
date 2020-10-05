using MongoDB.Driver;
using syshealth_api.Data;
using syshealth_api.DataTransferObjects;
using syshealth_api.Domain;
using syshealth_api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace syshealth_api.Core
{
    public class PedidoInternacaoAction : BaseAction
    {
        public PedidoInternacaoAction(IMongoDbSettings mongoDbSettings) : base(mongoDbSettings)
        {

        }

        public Leito VerificarLeitoDisponivel(double codigoTipoLeito,
                                              double codigoClassificacaoPaciente,
                                              DateTime dataSolicitacaoInternacao)
        {
            var filterLeito = Builders<Leito>.Filter.And($"{{CodigoStatusLeito: {(int)EnStatusLeito.Vago}}}",
                                                         $"{{CodigoTipoLeito:{codigoTipoLeito}}}");

            var updateLeito = Builders<Leito>.Update.Set("CodigoStatusLeito", (int)EnStatusLeito.Ocupado);

            var leitoDisponivel = db.GetCollection<Leito>(typeof(Leito).Name).FindOneAndUpdate(filterLeito, updateLeito);

            return leitoDisponivel;
        }

        public PedidoInternacao GravarPedidoInternacao(PedidoInternacaoDTO objPedidoInternacao)
        {
            var pacienteCollection = GetCollection<Paciente>();
            var pedidoInternacaoCollection = GetCollection<PedidoInternacao>();

            var paciente = new Paciente
            {
                Codigo = pacienteCollection.EstimatedDocumentCount() + 1,
                DataNascimento = DateTime.Parse(objPedidoInternacao.Paciente.DataNascimento),
                Endereco = objPedidoInternacao.Paciente.Endereco,
                EstadoCivil = objPedidoInternacao.Paciente.EstadoCivil.ToString(),
                Nome = objPedidoInternacao.Paciente.Nome,
                NomeMae = objPedidoInternacao.Paciente.NomeMae,
                NumeroCpf = objPedidoInternacao.Paciente.Cpf,
                NumeroRg = objPedidoInternacao.Paciente.Rg,
                NumeroSus = objPedidoInternacao.Paciente.NumeroSus,
                Sexo = objPedidoInternacao.Paciente.Sexo
            };

            var pedidoInternacao = new PedidoInternacao
            {
                Codigo = pedidoInternacaoCollection.EstimatedDocumentCount() + 1,
                Classificacao = objPedidoInternacao.CodigoClassificacao,
                CodigoUsuario = objPedidoInternacao.CodigoUsuario,
                DataHoraSolicitacao = DateTime.Now,
                MedicoSolicitante = objPedidoInternacao.NomeMedico,
                Motivo = objPedidoInternacao.Motivo,
                CodigoPaciente = paciente.Codigo,
                CodigoTipoLeito = objPedidoInternacao.CodigoTipoLeito
            };

            var leitoDisponivel = VerificarLeitoDisponivel(pedidoInternacao.CodigoTipoLeito,
                                                           pedidoInternacao.Classificacao,
                                                           pedidoInternacao.DataHoraSolicitacao);

            if (leitoDisponivel != null)
            {
                pedidoInternacao.CodigoLeito = leitoDisponivel.Codigo;
                pedidoInternacao.CodigoStatusPedidoInternacao = (int)EnStatusPedidoInternacao.Atendimento;
                pedidoInternacao.DataInternacao = DateTime.Now;
            }
            else
            {
                pedidoInternacao.CodigoStatusPedidoInternacao = (int)EnStatusPedidoInternacao.Aberto;
            }

            pacienteCollection.InsertOne(paciente);

            pedidoInternacaoCollection.InsertOne(pedidoInternacao);

            return pedidoInternacao;

        }
    }
}
