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
using syshealth_api.Data;
using syshealth_api.Domain;

namespace syshealth_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ParentController<Usuario>
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
            return Listar(id);
        }

        [HttpPost]
        public void Post([FromBody] Usuario objUsuario)
        {
            Gravar(objUsuario);
        }

        [HttpPut("{id}")]
        public void Update(string id, [FromBody] Usuario objUsuario)
        {
            var update = Builders<Usuario>.Update
                .Set("IdPerfil", objUsuario.IdPerfil)
                .Set("Nome", objUsuario.Nome)
                .Set("Login", objUsuario.Login)
                .Set("Senha", objUsuario.Senha)
                .Set("NumeroSUS", objUsuario.NumeroSUS)
                .Set("NumeroMatricula", objUsuario.NumeroMatricula)
                .Set("Funcionario", objUsuario.Funcionario);

            Atualizar(id, update);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Deletar(id);
        }
    }
}
