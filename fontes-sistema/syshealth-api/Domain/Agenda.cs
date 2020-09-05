﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Domain
{
    public class Agenda : DomainBase
    {
        public double CodigoUsuario { get; set; }

        public DateTime Data { get; set; }

        public double CodigoHorario { get; set; }

        public double CodigoPaciente { get; set; }

        public double CodigoMedico { get; set; }

        public double CodigoTipoExame { get; set; }

        public string NomeResponsavelExame { get; set; }
    }
}
