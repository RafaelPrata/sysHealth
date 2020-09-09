using MongoDB.Driver;
using syshealth_api.Data;
using syshealth_api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace syshealth_api.Core
{
    public class AgendaAction : BaseAction
    {
        public AgendaAction(IMongoDbSettings mongoDbSettings) : base(mongoDbSettings)
        {

        }

        public bool VerificarHorarioDisponivelConsulta(DateTime data, double codigoHorario, double codigoMedico)
        {
            var collection = db.GetCollection<Agenda>(typeof(Agenda).Name);

            var horarioIndisponivel = collection.Find(x => x.Data == data && 
                                                           x.CodigoHorario == codigoHorario && 
                                                           x.CodigoMedico == codigoMedico).Any();

            return horarioIndisponivel;
        }

        public bool VerificarHorarioDisponivelExame(DateTime data, double codigoHorario, double codigoTipoExame)
        {
            var collection = db.GetCollection<Agenda>(typeof(Agenda).Name);

            var horarioIndisponivel = collection.Find(x => x.Data == data &&
                                                           x.CodigoHorario == codigoHorario &&
                                                           x.CodigoTipoExame == codigoTipoExame).Any();

            return horarioIndisponivel;
        }

    }
}
