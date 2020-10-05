import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UsuarioApiService } from './usuarioApi.service';
import { Usuario } from '../models/Usuario';
import { LocalVariables } from '../util/localVariables';

@Injectable({
    providedIn: 'root'
})
export class AutenticacaoService {

    public autenticado: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

    constructor(private usuarioApiService: UsuarioApiService) {

    }

    public setAutenticado(val: boolean) {

        this.autenticado.next(val);
    }

    logOut() {
        LocalVariables.limparDados();
        this.setAutenticado(false);
    }

    public logIn(login: string, senha: string): Observable<boolean> {

        return new Observable((observer) => {

            this.usuarioApiService.autenticar(login, senha).subscribe((usuario: Usuario) => {

                if (usuario) {
                    LocalVariables.setVariable("nomeUsuario", usuario.nome);
                    LocalVariables.setVariable("codigoUsuario", usuario.codigo.toString());                    
                    LocalVariables.setVariable("codigoPerfilUsuario", usuario.codigoPerfil.toString());                    

                    //this.setAutenticado(true);

                    observer.next(true);
                }
                else {
                    LocalVariables.limparDados();

                    //this.setAutenticado(false);

                    observer.next(false);
                }

                observer.complete();

            });

        });

    }

}
