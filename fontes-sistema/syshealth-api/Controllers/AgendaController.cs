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

namespace syshealth_api.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : ParentController<Agenda, AgendaAction>
    {
        public AgendaController(ILogger<AgendaController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        [Route("{codigo}")]
        [Route("/agenda")]
        public IEnumerable<Agenda> Get(double? codigo)
        {
            return this.Action.Listar<Agenda>(codigo);
        }

        [HttpGet]
        [Route("/agenda/horarios")]
        public IEnumerable<Horario> GetHorarios()
        {
            return this.Action.GetCollection<Horario>().Find(_ => true).ToList();
        }

        [HttpGet]
        [Route("/agenda/tiposExames")]
        public IEnumerable<TipoExame> GetTiposExames()
        {
            return this.Action.GetCollection<TipoExame>().Find(_ => true).ToList();
        }

        [HttpGet]
        [Route("/agenda/medicos")]
        public IEnumerable<Medico> GetMedicos()
        {
            return this.Action.GetCollection<Medico>().Find(_ => true).ToList();
        }

        [HttpGet]
        [Route("/agenda/medico/especialidades")]
        public IEnumerable<Especialidade> GetEspecialidades()
        {
            return this.Action.GetCollection<Especialidade>().Find(_ => true).ToList();
        }

        [HttpGet]
        [Route("/agenda/consulta")]
        public IEnumerable<AgendaConsultaDisponivelDTO> ListarOpcoesConsulta([FromQuery] PesquisaAgendaDTO request)
        {
            request.CodigoTipoAgenda = 1;

           return this.Action.PesquisarHorarioDisponivel(request);
        }

        [HttpPost]
        [Route("/agenda/consulta")]
        public void AgendarConsultaMedica([FromBody] Agenda objAgenda)
        {
            var agendaDisponivel = Action.VerificarHorarioDisponivelConsulta(objAgenda.Data, 
                                                                             objAgenda.CodigoHorario, 
                                                                             objAgenda.CodigoMedico);

            if (agendaDisponivel)
                Action.Gravar(objAgenda);
            else
            {
                NotFound();
            }
        }

        [HttpPost]
        [Route("/agenda/exame")]
        public void AgendarExameMedico([FromBody] Agenda objAgenda)
        {
            var agendaDisponivel = Action.VerificarHorarioDisponivelExame(objAgenda.Data,
                                                                          objAgenda.CodigoHorario,
                                                                          objAgenda.CodigoTipoExame);

            if (agendaDisponivel)
                Action.Gravar(objAgenda);
            else
            {
                NotFound();
            }
        }

        [HttpPut("{codigo}")]
        public void Update(double codigo, [FromBody] Agenda objAgenda)
        {
            var update = Builders<Agenda>.Update
                .Set("xxxxxxxx", 123);

            this.Action.Atualizar(codigo, update);
        }

        [HttpDelete("{codigo}")]
        public void Delete(double codigo)
        {
            this.Action.Deletar<Agenda>(codigo);
        }
    }
}
