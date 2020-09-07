using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using syshealth_api.Core;
using syshealth_api.Data;
using syshealth_api.Domain;

namespace syshealth_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PerfilController : ParentController<Perfil, PerfilAction>
    {        
        public PerfilController(ILogger<PerfilController> logger, IMongoDbSettings mongoDbSettings) : 
            base(logger, mongoDbSettings)
        {            
            
        }

        [HttpGet]
        [Route("{id}")]
        [Route("/Perfil")]
        public IEnumerable<Perfil> Get(string id)
        {
            return this.Action.Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] Perfil objPerfil)
        {
            this.Action.Gravar(objPerfil);
        }

        [HttpPut("{codigo}")]
        public void Update(double codigo, [FromBody] Perfil objPerfil)
        {
            var update = Builders<Perfil>.Update
                .Set("xxxxxxxx", 123);

            this.Action.Atualizar(codigo, update);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.Action.Deletar(id);
        }
    }
}
