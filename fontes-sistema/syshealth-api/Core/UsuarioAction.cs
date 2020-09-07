using syshealth_api.Data;
using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Core
{
    public class UsuarioAction : BaseAction<Usuario>
    {
        public UsuarioAction(IMongoDbSettings mongoDbSettings) : base(mongoDbSettings)
        {

        }
    }
}
