import { Component, OnInit } from '@angular/core';
import { LoaderService } from '../services/loader.service';
import { DadosTelaConsultaMedica } from '../models/responseDTO/DadosTelaConsultaMedica';
import { AgendaApiService } from '../services/agendaApi.service';
import { Dominio } from '../models/Dominio';
import { PesquisarAgendaDTO } from '../models/requestDTO/pesquisarAgendaDTO';
import { Agenda } from '../models/Agenda';
import { LocalVariables } from '../util/localVariables';
import { now } from 'jquery';

@Component({
    selector: 'consulta-medica',
    templateUrl: './consulta-medica.component.html',
    styleUrls: ['./consulta-medica.component.css']
})
export class ConsultaMedicaComponent implements OnInit {

    private dadosTela: DadosTelaConsultaMedica;

    constructor(private agendaApiService: AgendaApiService) { }

    ngOnInit(): void {

        this.dadosTela = new DadosTelaConsultaMedica();

        this.agendaApiService.getEspecialidade().subscribe((especialidades: Dominio[]) => {
            this.dadosTela.listaEspecialidade = especialidades;
        });
    }

    pesquisar(event: any) {

        let request: PesquisarAgendaDTO = new PesquisarAgendaDTO();

        request.codigoServico = event.target.selFiltroEspecialidade.value;
        request.data = event.target.txtData.value;

        this.agendaApiService.listarOpcoesConsulta(request)
            .subscribe((listaOpcoesConsulta: any) => {
                this.dadosTela.listaOpcoesConsulta = listaOpcoesConsulta;                
            });

    }

    marcarConsulta(event, item: any) {
        
        let codigoHorarioSelecionado = $(event.currentTarget.parentElement.parentElement)
            .find($("[name='selHorarioDisponivel']")).val();

        let dadosConsulta: Agenda = new Agenda();

        dadosConsulta.codigoHorario = Number(codigoHorarioSelecionado);
        dadosConsulta.codigoMedico = item.codigoMedico;
        dadosConsulta.codigoUsuario = LocalVariables.codigoUsuario();
        dadosConsulta.Data = new Date(item.data);


        this.agendaApiService.cadastrarConsulta(dadosConsulta).subscribe((dadosConsulta) => {
            alert('Consulta marcada com sucesso.');
        },
            (error) => {
                alert('Erro ao marcar consulta');
            });
    }

}
