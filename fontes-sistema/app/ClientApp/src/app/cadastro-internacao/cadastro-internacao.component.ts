import { Component, OnInit } from '@angular/core';
import { DadosInternacao } from 'app/models/DadosInternacao';
import { PesquisarInternacaoDTO } from 'app/models/requestDTO/pesquisarInternacaoDTO';
import { DadosTelaCadastroInternacao } from 'app/models/responseDTO/DadosTelaCadastroInternacao';
import { InternacaoApiService } from 'app/services/internacaoApi.service';
// import {NgForm} from '@angular/forms';

@Component({
    selector: 'cadastro-internacao',
    templateUrl: './cadastro-internacao.component.html',
    styleUrls: ['./cadastro-internacao.component.css'],
    providers: [InternacaoApiService]
})
export class CadastroInternacaoComponent implements OnInit {

    private internacao: DadosInternacao

    private listaInternacao: DadosInternacao[]

    private dadosTela: DadosTelaCadastroInternacao

    public modoConsulta:boolean;

    constructor(private internacaoApiService: InternacaoApiService) {
        this.internacao = new DadosInternacao();
        this.dadosTela = new DadosTelaCadastroInternacao();
        this.modoConsulta = true;
    }

    ngOnInit() {

    }    

    exibirFormularioCadastro(codigoInternacao: number = null) {

        this.modoConsulta = false;

        if (codigoInternacao) {
            this.listarInternacao(codigoInternacao);
        }
        else
            this.limparCampos();

    }

    limparCampos(){

    }

    listarInternacao(codigoInternacao: number = null) {

        let request: PesquisarInternacaoDTO = new PesquisarInternacaoDTO();

        if(codigoInternacao){
            request.codigoInternacao = codigoInternacao.toString();
        }

        this.internacaoApiService.listarInternacao(request)
            .subscribe((listaInternacao: DadosInternacao[]) => {

                if (codigoInternacao) {
                    this.internacao = listaInternacao[0]
                }
                else
                    this.listaInternacao = listaInternacao;

            });
    }

    excluirCadastro(codigo: number){

    }

    cadastrarNovo(){
        this.modoConsulta = false;
    }

    cadastrar(){
        console.log(this.internacao);
    }

    voltarListaUsuario(){        
        this.modoConsulta = true;
    }

    pesquisar(event: any){

        let request: PesquisarInternacaoDTO = new PesquisarInternacaoDTO();

        request.codigoInternacao = event.target.txtFiltroNumeroInternacao.value;
        request.nomePaciente = event.target.txtFiltroNomePaciente.value;
        request.codigoClassificacao = event.target.selFiltroClassificacao.value;
        request.codigoStatus = event.target.selFiltroStatus.value;  
        
        this.internacaoApiService.listarInternacao(request)
                                    .subscribe((listaInternacao: DadosInternacao[]) =>{
            this.listaInternacao = listaInternacao;
        });
                
    }

}
