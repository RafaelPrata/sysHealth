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
export class InternacaoApiService extends ApiService {

  //private http: HttpClient;
  //private urlApi: string;

  constructor(private http: HttpClient) { 
    super();   
  }

  listarInternacao(parametros : PesquisarInternacaoDTO = null): Observable<DadosInternacao[]>{

    if(parametros.codigoInternacao){
      return this.http.get<DadosInternacao[]>(`${this.urlApi}/usuario/${parametros.codigoInternacao}`);
    }
    else{

      let httpParams : HttpParams = new HttpParams().set("nomePaciente", parametros.nomePaciente)
                                                    .set("codigoClassificacao", parametros.codigoClassificacao)
                                                    .set("codigoStatus", parametros.codigoStatus);

      return this.http.get<DadosInternacao[]>(`${this.urlApi}/usuario`, {params : httpParams});
    }
     

  }

  cadastrarInternacao(dadosInternacao: DadosInternacao): Observable<DadosInternacao>{
        
      var url = dadosInternacao.codigo ? `${this.urlApi}/usuario/${dadosInternacao.codigo}` : `${this.urlApi}/usuario`;
      
      return dadosInternacao.codigo ? this.http.put<DadosInternacao>(url, dadosInternacao) : this.http.post<DadosInternacao>(url, dadosInternacao);
  }

  deletarInternacao(codigoUsuario: number): Observable<{}>{
    return this.http.delete(`${this.urlApi}/usuario/${codigoUsuario}`, {});    
  }

  listarPerfil(): Observable<Dominio[]>{
    return this.http.get<Dominio[]>(`${this.urlApi}/perfil`);
  }

}
