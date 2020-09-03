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
    public class MedicoController : ParentController<Medico>
    {
        public MedicoController(ILogger<MedicoController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        [Route("{id}")]
        [Route("/Medico")]
        public IEnumerable<Medico> Get(string id)
        {
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] Medico objMedico)
        {
            Gravar(objMedico);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] Medico objMedico)
        {
            var update = Builders<Medico>.Update
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
