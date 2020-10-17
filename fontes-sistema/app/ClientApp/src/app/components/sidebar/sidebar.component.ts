import { Component, OnInit, Input, SimpleChanges } from '@angular/core';
import { LocalVariables } from '../../util/localVariables';

declare const $: any;
declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
    perfil: number;
}
export const ROUTES: RouteInfo[] = [
    { path: '/home', title: 'Home', icon: 'dashboard', perfil: 1, class: '' },
    { path: '/cadastro-usuario', title: 'Cadastro de Usuário', icon: 'person', perfil: 1, class: '' },
    { path: '/cadastro-internacao', title: 'Internações', icon: 'content_paste', perfil: 2, class: '' },
    { path: '/consulta-medica', title: 'Consulta médica', icon: 'content_paste', perfil: 3, class: '' },
    { path: '/exame-medico', title: 'Exame médico', icon: 'content_paste', perfil: 3, class: '' },
    { path: '/central-leitos', title: 'Central de leitos', icon: 'content_paste', perfil: 2, class: '' },
    // { path: '/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
    // { path: '/maps', title: 'Maps',  icon:'location_on', class: '' },
    // { path: '/notifications', title: 'Notifications',  icon:'notifications', class: '' },
    // { path: '/upgrade', title: 'Upgrade to PRO',  icon:'unarchive', class: 'active-pro' },
];

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
    menuItems: any[];

    @Input()
    codigoPerfilUsuario: number;

    constructor() { }

    ngOnChanges(changes: SimpleChanges) {        
        this.menuItems = LocalVariables.codigoPerfilUsuario() == 1 ? ROUTES.filter(menuItem => menuItem) :
            ROUTES.filter(menuItem => menuItem.perfil == LocalVariables.codigoPerfilUsuario());
    }

    ngOnInit() {

    }

    isMobileMenu() {
        if ($(window).width() > 991) {
            return false;
        }
        return true;
    };
}
