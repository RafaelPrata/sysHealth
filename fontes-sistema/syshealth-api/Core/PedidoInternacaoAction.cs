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

        public void GravarPedidoInternacao(PedidoInternacaoDTO objPedidoInternacao)
        {
            var pacienteCollection = GetCollection<Paciente>();
            var pedidoInternacaoCollection = GetCollection<PedidoInternacao>();

            var leitoDisponivel = VerificarLeitoDisponivel(1, 1, DateTime.Now);

            var paciente = new Paciente
            {
                Codigo = pacienteCollection.EstimatedDocumentCount() + 1,
                DataNascimento = objPedidoInternacao.Paciente.DataNasicmento,
                Endereco = objPedidoInternacao.Paciente.Endereco,
                EstadoCivil = objPedidoInternacao.Paciente.EstadoCivil,
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
                Classificacao = objPedidoInternacao.Classificacao,
                CodigoUsuario = objPedidoInternacao.CodigoUsuario,
                DataHoraSolicitacao = DateTime.Now,
                MedicoSolicitante = objPedidoInternacao.NomeMedicoSolicitante,
                Motivo = objPedidoInternacao.Motivo,
                CodigoPaciente = paciente.Codigo,
                CodigoTipoLeito = objPedidoInternacao.CodigoTipoLeito
            };

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

        }
    }
}
