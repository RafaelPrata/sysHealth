using syshealth_api.Domain;
using System;

namespace syshealth_api.Domain
{
    public class Usuario : DomainBase
    {
        public int IdUsuario { get; set; }

        public int IdPerfil { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string NumeroSUS { get; set; }

        public string NumeroMatricula { get; set; }

        public string Funcionario { get; set; }
    }
}


