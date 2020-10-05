import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AutenticacaoService } from '../services/autenticacao.service';
import { LocalVariables } from '../util/localVariables';

@Injectable()
export class AuthGuard implements CanActivate {

    constructor(private router: Router,
                private autenticacaoService: AutenticacaoService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (LocalVariables.getVariable('codigoUsuario')) {
            this.autenticacaoService.setAutenticado(true);
            return true;
        }
        else {
            this.autenticacaoService.setAutenticado(false);
            //this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });

            return false;
        } 
                
    }
}
