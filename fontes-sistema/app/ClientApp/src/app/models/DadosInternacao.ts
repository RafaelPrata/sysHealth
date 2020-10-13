import { DadosPaciente } from "./DadosPaciente";

export class DadosInternacao {  
    codigo: number;
    paciente: DadosPaciente;
    nomeMedico: string;
    codigoClassificacao: number;
    motivo: string;
    dataHoraSolicitacao: Date;
    dataNascimento: string;
    codigoUsuario: number
    
    constructor(){
        this.paciente = new DadosPaciente();
    }
}
