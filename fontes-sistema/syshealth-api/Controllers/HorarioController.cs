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
    public class HorarioController : ParentController<Horario>
    {        
        public HorarioController(ILogger<HorarioController> logger, IMongoDbSettings mongoDbSettings) : 
            base(logger, mongoDbSettings)
        {            
            
        }

        [HttpGet]
        [Route("{id}")]
        [Route("/Horario")]
        public IEnumerable<Horario> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] Horario objHorario)
        {
            Gravar(objHorario);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] Horario objHorario)
        {
            var update = Builders<Horario>.Update
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
