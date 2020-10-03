import { Dominio } from "../Dominio";

export class DadosTelaCadastroInternacao {
    listaClassificao: Dominio[]
    listaStatus: Dominio[]
    listaEstados: any[]

    constructor() {
        this.listaEstados = [
            { "sigla": "AC" },
            { "sigla": "AL" },
            { "sigla": "AP" },
            { "sigla": "AM" },
            { "sigla": "BA" },
            { "sigla": "CE" },
            { "sigla": "DF" },
            { "sigla": "ES" },
            { "sigla": "GO" },
            { "sigla": "MA" },
            { "sigla": "MT" },
            { "sigla": "MS" },
            { "sigla": "MG" },
            { "sigla": "PA" },
            { "sigla": "PB" },
            { "sigla": "PR" },
            { "sigla": "PE" },
            { "sigla": "PI" },
            { "sigla": "RJ" },
            { "sigla": "RN" },
            { "sigla": "RS" },
            { "sigla": "RO" },
            { "sigla": "RR" },
            { "sigla": "SC" },
            { "sigla": "SP" },
            { "sigla": "SE" },
            { "sigla": "TO" }
        ];
    }
}
