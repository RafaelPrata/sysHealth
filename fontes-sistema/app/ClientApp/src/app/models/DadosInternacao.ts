import { DadosPaciente } from "./DadosPaciente";

export class DadosInternacao {  
    codigo: number;
    paciente: DadosPaciente;
    nomeMedico: string;
    codigoClassificacao: number;
    motivo: string;   
    
    constructor(){
        this.paciente = new DadosPaciente();
    }
}
