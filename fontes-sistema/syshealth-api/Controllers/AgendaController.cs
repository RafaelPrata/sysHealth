﻿using System;
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
    public class AgendaController : ParentController<Agenda>
    {
        public AgendaController(ILogger<AgendaController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        public IEnumerable<Agenda> Get()
        {
            var teste =  GetCollection().Find(_ => true).ToList();

            return teste;
        }
    }
}
