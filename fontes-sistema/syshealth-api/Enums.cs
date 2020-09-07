using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace syshealth_api.Enums
{
    public enum EnStatusPedidoInternacao
    {
        Aberto = 1,
        Atendimento = 2,
        Concluido = 3
    }

    public enum EnStatusLeito
    {
        Ocupado = 1,
        Vago = 2,
        Reservado = 3
    }

    public enum EnClassificacao
    {
        Vermelho = 1,
        Laranja = 2,
        Amarelo = 3,
        Verde = 4,
        Azul = 5,
    }

}
