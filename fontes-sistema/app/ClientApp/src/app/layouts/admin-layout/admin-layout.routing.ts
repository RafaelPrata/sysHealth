import { Routes } from '@angular/router';

import { DashboardComponent } from '../../dashboard/dashboard.component';
import { CadastroUsuarioComponent } from '../../cadastro-usuario/cadastro-usuario.component';
import { CadastroInternacaoComponent } from '../../cadastro-internacao/cadastro-internacao.component';
import { ConsultaMedicaComponent } from 'app/consulta-medica/consulta-medica.component';
import { ExameMedicoComponent } from 'app/exame-medico/exame-medico.component';
import { CentralLeitosComponent } from 'app/central-leitos/central-leitos.component';

export const AdminLayoutRoutes: Routes = [
    // {
    //   path: '',
    //   children: [ {
    //     path: 'dashboard',
    //     component: DashboardComponent
    // }]}, {
    // path: '',
    // children: [ {
    //   path: 'userprofile',
    //   component: UserProfileComponent
    // }]
    // }, {
    //   path: '',
    //   children: [ {
    //     path: 'icons',
    //     component: IconsComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'notifications',
    //         component: NotificationsComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'maps',
    //         component: MapsComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'typography',
    //         component: TypographyComponent
    //     }]
    // }, {
    //     path: '',
    //     children: [ {
    //         path: 'upgrade',
    //         component: UpgradeComponent
    //     }]
    // }
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'cadastro-usuario', component: CadastroUsuarioComponent },
    { path: 'cadastro-internacao', component: CadastroInternacaoComponent },
    { path: 'consulta-medica', component: ConsultaMedicaComponent },
    { path: 'exame-medico', component: ExameMedicoComponent },
    { path: 'central-leitos', component: CentralLeitosComponent },
];
