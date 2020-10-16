using MongoDB.Driver;
using syshealth_api.Data;
using syshealth_api.DataTransferObjects;
using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace syshealth_api.Core
{
    public class AgendaAction : BaseAction
    {
        public AgendaAction(IMongoDbSettings mongoDbSettings) : base(mongoDbSettings)
        {

        }

        public bool VerificarHorarioDisponivelConsulta(DateTime data, double codigoHorario, double codigoMedico)
        {
            var collection = db.GetCollection<Agenda>(typeof(Agenda).Name);

            var horarioIndisponivel = collection.Find(x => x.Data == data &&
                                                           x.CodigoHorario == codigoHorario &&
                                                           x.CodigoMedico == codigoMedico).Any();

            return !horarioIndisponivel;
        }

        public bool VerificarHorarioDisponivelExame(DateTime data, double codigoHorario, double codigoTipoExame)
        {
            var collection = db.GetCollection<Agenda>(typeof(Agenda).Name);

            var horarioIndisponivel = collection.Find(x => x.Data == data &&
                                                           x.CodigoHorario == codigoHorario &&
                                                           x.CodigoTipoExame == codigoTipoExame).Any();

            return !horarioIndisponivel;
        }

        public List<AgendaConsultaDisponivelDTO> PesquisarHorarioDisponivelConsulta(PesquisaAgendaDTO request)
        {
            var filterBuilder = Builders<Agenda>.Filter;
            var filters = new List<FilterDefinition<Agenda>>();

            var lista = new List<AgendaConsultaDisponivelDTO>();
            var listaHorarios = db.GetCollection<Horario>(typeof(Horario).Name).Find(_ => true).ToList();
            var listaMedicos = db.GetCollection<Medico>(typeof(Medico).Name).Find(x => x.CodigoEspecialidade == request.CodigoServico).ToList();

            filters.Add(filterBuilder.Eq("Data", request.Data));
            filters.Add(filterBuilder.In("CodigoMedico", listaMedicos.Select(x => x.Codigo)));

            var listaAgenda = db.GetCollection<Agenda>(typeof(Agenda).Name).Find(filterBuilder.And(filters)).ToList();


            listaMedicos.ForEach(medicoItem =>
            {
                var listaHorariosAux = listaHorarios.Select(x => x).ToList();

                var agendaMedico = listaAgenda.FindAll(x => x.CodigoMedico == medicoItem.Codigo);

                agendaMedico.ForEach(agendaItem => listaHorariosAux.RemoveAll(x => x.Codigo == agendaItem.CodigoHorario));

                lista.Add(new AgendaConsultaDisponivelDTO
                {
                    CodigoMedico = medicoItem.Codigo,
                    NomeMedico = medicoItem.Nome,
                    Crm = medicoItem.CRM,
                    Data = request.Data,
                    Horarios = listaHorariosAux
                });

            });


            return lista;
        }

        public AgendaExameDisponivelDTO PesquisarHorarioDisponivelExame(PesquisaAgendaDTO request)
        {

            var lista = new List<AgendaExameDisponivelDTO>();
            var listaHorarios = db.GetCollection<Horario>(typeof(Horario).Name).Find(_ => true).ToList();

            var listaAgenda = db.GetCollection<Agenda>(typeof(Agenda).Name).Find(x => x.Data == request.Data &&
                                                                                      x.CodigoTipoExame == request.CodigoServico).ToList();


            listaAgenda.ForEach(agendaItem => listaHorarios.RemoveAll(x => x.Codigo == agendaItem.CodigoHorario));

            return new AgendaExameDisponivelDTO
            {
                CodigoTipoExame = request.CodigoServico.ToString(),
                Data = request.Data,
                Horarios = listaHorarios
            };

        }

    }
}
