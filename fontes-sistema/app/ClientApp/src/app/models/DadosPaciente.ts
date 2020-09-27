import { Endereco } from "./Endereco";

export class DadosPaciente {  
    nome: string;
    dataNascimento: Date;
    sexo: string;
    codigoEstadoCivil: number;
    cpf: string;
    rg: string;
    numeroSus: string;
    nomeMae: string;
    endereco: Endereco;

    constructor(){
        this.endereco = new Endereco();
    }
}
