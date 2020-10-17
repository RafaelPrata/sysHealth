import { Component, OnInit } from '@angular/core';
import { DadosInternacao } from 'app/models/DadosInternacao';
import { PesquisarInternacaoDTO } from 'app/models/requestDTO/pesquisarInternacaoDTO';
import { DadosTelaCadastroInternacao } from 'app/models/responseDTO/DadosTelaCadastroInternacao';
import { InternacaoApiService } from 'app/services/internacaoApi.service';
import { Dominio } from '../models/Dominio';
import { error } from 'jquery';
import { LocalVariables } from '../util/localVariables';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../components/dialog/dialog.component';
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

    public modoConsulta: boolean;

    constructor(private internacaoApiService: InternacaoApiService,
        private dialog: MatDialog) {
        this.internacao = new DadosInternacao();
        this.dadosTela = new DadosTelaCadastroInternacao();
        this.modoConsulta = true;
    }

    ngOnInit() {

        this.listarInternacao();

        this.internacaoApiService.listarStatus().subscribe((listaStatus: Dominio[]) => {
            this.dadosTela.listaStatus = listaStatus;
        })

        this.internacaoApiService.listarClassificacao().subscribe((listaClassificacao: Dominio[]) => {
            this.dadosTela.listaClassificacao = listaClassificacao;
        })

    }

    exibirFormularioCadastro(codigoInternacao: number = null) {

        this.modoConsulta = false;

        if (codigoInternacao) {
            this.internacaoApiService.getInternacao(codigoInternacao).subscribe((dadosInternacao: DadosInternacao) => {

                this.internacao = dadosInternacao;

                console.log(this.internacao);

            }, (error) => console.log(error));
        }
        else
            this.internacao = new DadosInternacao();

    }


    listarInternacao() {

        this.internacaoApiService.listarInternacao()
            .subscribe((listaInternacao: DadosInternacao[]) => {

                this.listaInternacao = listaInternacao;
            });
    }

    excluirCadastro(codigo: number) {

    }

    cadastrarNovo() {
        this.modoConsulta = false;
        this.internacao = new DadosInternacao();
    }

    cadastrar() {

        this.internacao.codigoUsuario = LocalVariables.codigoUsuario();

        this.internacaoApiService.cadastrarInternacao(this.internacao)
            .subscribe((dados: DadosInternacao) => {

                this.dialog.open(DialogComponent, {
                    data: {
                        titulo: 'Informação',
                        mensagem: 'Pedido de internação cadastrada.'
                    }
                });

                this.listaInternacao.push(dados);
                this.internacao = new DadosInternacao();
            });
    }

    voltarListaUsuario() {
        this.modoConsulta = true;
    }

    pesquisar(event: any) {

        let request: PesquisarInternacaoDTO = new PesquisarInternacaoDTO();

        request.codigoInternacao = event.target.txtFiltroNumeroInternacao.value;
        request.nomePaciente = event.target.txtFiltroNomePaciente.value;
        request.codigoClassificacao = event.target.selFiltroClassificacao.value;
        request.codigoStatus = event.target.selFiltroStatus.value;

        this.internacaoApiService.listarInternacao(request)
            .subscribe((listaInternacao: DadosInternacao[]) => {
                this.listaInternacao = listaInternacao;
            });

    }

}
