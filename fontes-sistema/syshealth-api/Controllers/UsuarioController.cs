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

        [HttpPost]
        [Route("/Usuario/autenticar")]
        public Usuario Autenticar([FromBody] Usuario objUsuario)
        {
            var usuario = Action.BuscarUsuario(objUsuario.Login, objUsuario.Senha);

            return usuario;
        }

        [HttpGet]
        [Route("{codigo}")]
        [Route("/Usuario")]
        public IEnumerable<Usuario> Get(double? codigo)
        {
            return Action.Listar<Usuario>(codigo);
        }

        [HttpGet]
        [Route("/Usuario/EstadoCivil")]
        public IEnumerable<EstadoCivil> GetListaEstadoCivil()
        {
            return this.Action.GetCollection<EstadoCivil>().Find(_ => true).ToList();
        }

        [HttpPost]
        public Usuario Post([FromBody] Usuario objUsuario)
        {
            return this.Action.Gravar(objUsuario);            
        }

        [HttpPut("{codigo}")]
        public void Update(double codigo, [FromBody] Usuario objUsuario)
        {
            var update = Builders<Usuario>.Update
                .Set("CodigoPerfil", objUsuario.CodigoPerfil)
                .Set("Nome", objUsuario.Nome)
                .Set("Login", objUsuario.Login)
                .Set("Senha", objUsuario.Senha)
                .Set("NumeroSUS", objUsuario.NumeroSUS)
                .Set("NumeroMatricula", objUsuario.NumeroMatricula)
                .Set("Funcionario", objUsuario.Funcionario);

            this.Action.Atualizar(codigo, update);
        }

        [HttpDelete("{codigo}")]
        public void Delete(double codigo)
        {
            this.Action.Deletar<Usuario>(codigo);
        }
    }
}
