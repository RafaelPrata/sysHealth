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
        public IEnumerable<Especialidade> Get()
        {
            return GetCollection().Find(_ => true).ToList();
        }
    }
}
