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
    public class EspecialidadeController : ParentController<Especialidade>
    {        
        public EspecialidadeController(ILogger<EspecialidadeController> logger, IMongoDbSettings mongoDbSettings) : 
            base(logger, mongoDbSettings)
        {            
            
        }

        [HttpGet]
        [Route("{id}")]
        [Route("/especialidade")]
        public IEnumerable<Especialidade> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] Especialidade objEspecialidade)
        {
            Gravar(objEspecialidade);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] Especialidade objEspecialidade)
        {
            var update = Builders<Especialidade>.Update
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
