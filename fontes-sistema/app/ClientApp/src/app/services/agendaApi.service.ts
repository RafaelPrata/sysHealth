import { environment } from './../../environments/environment.prod';
import { Dominio } from '../models/Dominio';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PesquisarAgendaDTO } from '../models/requestDTO/pesquisarAgendaDTO';
import { Agenda } from '../models/Agenda';


@Injectable({
    providedIn: 'root'
})
export class AgendaApiService {

    //private http: HttpClient;
    //private urlApi: string;

    constructor(private http: HttpClient) {

    }

    getEspecialidade(): Observable<Dominio[]> {

        return this.http.get<Dominio[]>(`${environment.urlApi}/agenda/medico/especialidades`);
    }

    listarOpcoesConsulta(parametros: PesquisarAgendaDTO = null): Observable<any> {

        let httpParams: HttpParams = null;

        if (parametros) {
            httpParams = new HttpParams().set("codigoServico", parametros.codigoServico.toString())
                                         .set("data", parametros.data.toString());
        }

        return this.http.get<any>(`${environment.urlApi}/agenda/consulta`, { params: httpParams });

    }

    cadastrarConsulta(dadosConsulta: Agenda): Observable<Agenda> {
        return this.http.post<Agenda>(`${environment.urlApi}/agenda/consulta`, dadosConsulta);
    }

    //atualizarInternacao(dadosInternacao: DadosInternacao): Observable<DadosInternacao> {

    //    return this.http.put<DadosInternacao>(`${environment.urlApi}/pedidoInternacao/${dadosInternacao.codigo}`, dadosInternacao);
    //}

    //deletarInternacao(codigoInternacao: number): Observable<{}> {
    //    return this.http.delete(`${environment.urlApi}/pedidoInternacao/${codigoInternacao}`, {});
    //}

    //listarStatus() {
    //    return this.http.get<Dominio[]>(`${environment.urlApi}/pedidoInternacao/status`);
    //}

    //listarClassificacao() {
    //    return this.http.get<Dominio[]>(`${environment.urlApi}/pedidoInternacao/classificacao`);
    //}

}
