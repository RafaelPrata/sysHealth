import { environment } from './../../environments/environment.prod';
import { Dominio } from '../models/Dominio';
import { Usuario } from '../models/Usuario';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PesquisarUsuarioDTO } from 'app/models/requestDTO/pesquisarUsuarioDTO';
import { PesquisarInternacaoDTO } from 'app/models/requestDTO/pesquisarInternacaoDTO';
import { DadosInternacao } from 'app/models/DadosInternacao';

@Injectable({
  providedIn: 'root'
})
export class InternacaoApiService  {

  //private http: HttpClient;
  //private urlApi: string;

  constructor(private http: HttpClient) { 
  
    }

    getInternacao(codigoInternacao: number): Observable<DadosInternacao> {

        return this.http.get<DadosInternacao>(`${environment.urlApi}/pedidoInternacao/${codigoInternacao}`);                
    }

  listarInternacao(parametros : PesquisarInternacaoDTO = null): Observable<DadosInternacao[]>{

      //let httpParams : HttpParams = new HttpParams().set("nomePaciente", parametros.nomePaciente)
      //                                              .set("codigoClassificacao", parametros.codigoClassificacao)
      //                                              .set("codigoStatus", parametros.codigoStatus);

        return this.http.get<DadosInternacao[]>(`${environment.urlApi}/pedidoInternacao`, {});
         
  }

  cadastrarInternacao(dadosInternacao: DadosInternacao): Observable<DadosInternacao>{
                    
      return this.http.post<DadosInternacao>(`${environment.urlApi}/pedidoInternacao`, dadosInternacao);
    }

    atualizarInternacao(dadosInternacao: DadosInternacao): Observable<DadosInternacao> {
        
        return this.http.put<DadosInternacao>(`${environment.urlApi}/pedidoInternacao/${dadosInternacao.codigo}`, dadosInternacao);
    }

  deletarInternacao(codigoInternacao: number): Observable<{}>{
      return this.http.delete(`${environment.urlApi}/pedidoInternacao/${codigoInternacao}`, {});    
  }

    listarStatus() {
        return this.http.get<Dominio[]>(`${environment.urlApi}/pedidoInternacao/status`);
    }

    listarClassificacao() {
        return this.http.get<Dominio[]>(`${environment.urlApi}/pedidoInternacao/classificacao`);
    }

}
