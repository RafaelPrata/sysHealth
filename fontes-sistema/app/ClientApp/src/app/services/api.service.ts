import { Perfil } from './../models/Perfil';
import { Usuario } from './../models/Usuario';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  //private http: HttpClient;
  private urlApi: string;

  constructor(private http: HttpClient) { 
    //this.http = new HttpClient();
    this.urlApi = "http://localhost/sysHealthApi";    
    //this.urlApi = "http://localhost:44322";    
  }

  listarUsuarios(codigoUsuario: number = null): Observable<Usuario[]>{
    return codigoUsuario ? this.http.get<Usuario[]>(`${this.urlApi}/usuario/${codigoUsuario}`) :
                           this.http.get<Usuario[]>(`${this.urlApi}/usuario`);
  }

  cadastrarUsuario(usuario: Usuario): Observable<Usuario>{
        
      var url = usuario.codigo ? `${this.urlApi}/usuario/${usuario.codigo}` : `${this.urlApi}/usuario`;
      
      return usuario.codigo ? this.http.put<Usuario>(url, usuario) : this.http.post<Usuario>(url, usuario);
  }

  deletarUsuario(codigoUsuario: number): Observable<{}>{
    return this.http.delete(`${this.urlApi}/usuario/${codigoUsuario}`, {});    
  }

  listarPerfil(): Observable<Perfil[]>{
    return this.http.get<Perfil[]>(`${this.urlApi}/perfil`);
  }

}
