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
    public class PacienteController : ParentController<Paciente>
    {        
        public PacienteController(ILogger<PacienteController> logger, IMongoDbSettings mongoDbSettings) : 
            base(logger, mongoDbSettings)
        {            
            
        }

        [HttpGet]
        [Route("{id}")]
        [Route("/Paciente")]
        public IEnumerable<Paciente> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] Paciente objPaciente)
        {
            Gravar(objPaciente);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] Paciente objPaciente)
        {
            var update = Builders<Paciente>.Update
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
