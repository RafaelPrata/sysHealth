using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders.Testing;
using MongoDB.Bson;
using MongoDB.Driver;
using syshealth_api.Core;
using syshealth_api.Data;
using syshealth_api.Domain;

namespace syshealth_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ParentController<Usuario, UsuarioAction>
    {
        public UsuarioController(ILogger<UsuarioController> logger, IMongoDbSettings mongoDbSettings) :
            base(logger, mongoDbSettings)
        {

        }

        [HttpGet]
        [Route("{id}")]
        [Route("/Usuario")]
        public IEnumerable<Usuario> Get(string id)
        {
            return this.Action.Listar(id);
        }

        [HttpGet]
        [Route("/Usuario/EstadoCivil")]
        public IEnumerable<EstadoCivil> GetListaEstadoCivil()
        {
            return this.Action.GetCollection<EstadoCivil>().Find(_ => true).ToList();
        }

        [HttpPost]
        public void Post([FromBody] Usuario objUsuario)
        {
            this.Action.Gravar(objUsuario);
        }

        [HttpPut("{codigo}")]
        public void Update(double codigo, [FromBody] Usuario objUsuario)
        {
            var update = Builders<Usuario>.Update
                .Set("IdPerfil", objUsuario.CodigoPerfil)
                .Set("Nome", objUsuario.Nome)
                .Set("Login", objUsuario.Login)
                .Set("Senha", objUsuario.Senha)
                .Set("NumeroSUS", objUsuario.NumeroSUS)
                .Set("NumeroMatricula", objUsuario.NumeroMatricula)
                .Set("Funcionario", objUsuario.Funcionario);

            this.Action.Atualizar(codigo, update);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.Action.Deletar(id);
        }
    }
}
