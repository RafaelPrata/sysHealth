import { Component, OnInit } from '@angular/core';
import { LoaderService } from '../services/loader.service';
import { DadosTelaConsultaMedica } from '../models/responseDTO/DadosTelaConsultaMedica';
import { AgendaApiService } from '../services/agendaApi.service';
import { Dominio } from '../models/Dominio';
import { PesquisarAgendaDTO } from '../models/requestDTO/pesquisarAgendaDTO';
import { Agenda } from '../models/Agenda';
import { LocalVariables } from '../util/localVariables';
import { now } from 'jquery';
import { DadosTelaExameMedico } from '../models/responseDTO/DadosTelaExameMedico';

@Component({
    selector: 'exame-medico',
    templateUrl: './exame-medico.component.html',
    styleUrls: ['./exame-medico.component.css']
})
export class ExameMedicoComponent implements OnInit {

    public dadosTela: DadosTelaExameMedico;

    constructor(private agendaApiService: AgendaApiService) { }

    ngOnInit(): void {

        this.dadosTela = new DadosTelaExameMedico();

        this.agendaApiService.getTiposExames().subscribe((tiposExames: Dominio[]) => {
            this.dadosTela.listaTiposExames = tiposExames;
        });
    }

    pesquisar(event: any) {

        let request: PesquisarAgendaDTO = new PesquisarAgendaDTO();

        request.codigoServico = event.target.selFiltroTipoExame.value;
        request.data = event.target.txtData.value;

        this.agendaApiService.listarOpcoesExame(request)
            .subscribe((listaOpcoesExame: any) => {
                this.dadosTela.listaOpcoesExame = new Array(listaOpcoesExame);
                console.log(this.dadosTela.listaOpcoesExame);
            });

    }

    marcarExame(event, item: any) {

        let codigoHorarioSelecionado = $(event.currentTarget.parentElement.parentElement)
            .find($("[name='selHorarioDisponivel']")).val();

        let dadosConsulta: Agenda = new Agenda();

        dadosConsulta.codigoHorario = Number(codigoHorarioSelecionado);
        dadosConsulta.codigoTipoExame = item.codigoTipoExame;
        dadosConsulta.codigoUsuario = LocalVariables.codigoUsuario();
        dadosConsulta.Data = new Date(item.data);

        this.agendaApiService.cadastrarExame(dadosConsulta).subscribe((dadosConsulta) => {
            alert('Exame marcado com sucesso.');
        },
            (error) => {
                alert('Erro ao marcar exame');
            });
    }

}
