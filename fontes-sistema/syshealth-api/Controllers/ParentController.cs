using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using syshealth_api.Core;
using syshealth_api.Data;
using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Controllers
{
    public abstract class ParentController<T, ActionType> : ControllerBase where T : DomainBase
    {
        public ActionType Action { get; }

        private readonly ILogger<ControllerBase> _logger;

        public ParentController(ILogger<ControllerBase> logger, IMongoDbSettings mongoDbSettings)
        {
            _logger = logger;

            Action = (ActionType)Activator.CreateInstance(typeof(ActionType), mongoDbSettings);
        }
        
    }
}
