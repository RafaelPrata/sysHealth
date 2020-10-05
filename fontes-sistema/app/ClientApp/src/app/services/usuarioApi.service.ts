import { environment } from './../../environments/environment.prod';
import { Dominio } from '../models/Dominio';
import { Usuario } from '../models/Usuario';
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PesquisarUsuarioDTO } from 'app/models/requestDTO/pesquisarUsuarioDTO';

@Injectable({
    providedIn: 'root'
})
export class UsuarioApiService {

    constructor(private http: HttpClient) {

    }

    listarUsuarios(parametros: PesquisarUsuarioDTO = null): Observable<Usuario[]> {

        if (parametros.codigoUsuario) {
            return this.http.get<Usuario[]>(`${environment.urlApi}/usuario/${parametros.codigoUsuario}`);
        }
        else {

            let httpParams: HttpParams = new HttpParams().set("nome", parametros.nome)
                .set("login", parametros.login)
                .set("codigoPerfil", parametros.codigoPerfil);

            return this.http.get<Usuario[]>(`${environment.urlApi}/usuario`, { params: httpParams });
        }

    }

    autenticar(login: string, senha: string): Observable<Usuario> {
        return this.http.post<Usuario>(`${environment.urlApi}/usuario/autenticar`, {"login": login, "senha": senha });
    }

    cadastrarUsuario(usuario: Usuario): Observable<Usuario> {

        return this.http.post<Usuario>(`${environment.urlApi}/usuario`, usuario);
    }

    atualizarUsuario(usuario: Usuario): Observable<Usuario> {

        return this.http.put<Usuario>(`${environment.urlApi}/usuario/${usuario.codigo}`, usuario);
    }

    deletarUsuario(codigoUsuario: number): Observable<{}> {
        return this.http.delete(`${environment.urlApi}/usuario/${codigoUsuario}`, {});
    }

    listarPerfil(): Observable<Dominio[]> {
        return this.http.get<Dominio[]>(`${environment.urlApi}/perfil`);
    }

}
