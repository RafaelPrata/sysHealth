import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { UsuarioApiService } from './usuarioApi.service';
import { Usuario } from '../models/Usuario';

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

    public autenticar(login: string, senha: string): Observable<boolean> {

        return new Observable((observer) => {

            this.usuarioApiService.autenticar(login, senha).subscribe((usuario: Usuario) => {

                if (usuario) {
                    localStorage.setItem("codigoUsuario", usuario.codigo.toString());
                    localStorage.setItem("codigoPerfilUsuario", usuario.codigoPerfil.toString());

                    //this.setAutenticado(true);

                    observer.next(true);
                }
                else {
                    //this.setAutenticado(false);

                    observer.next(false);
                }

                observer.complete();

            });

        });

    }

}
