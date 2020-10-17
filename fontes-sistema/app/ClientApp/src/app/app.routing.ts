import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { CadastroInternacaoComponent } from './cadastro-internacao/cadastro-internacao.component';
import { ConsultaMedicaComponent } from './consulta-medica/consulta-medica.component';
import { ExameMedicoComponent } from './exame-medico/exame-medico.component';
import { CentralLeitosComponent } from './central-leitos/central-leitos.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'home',
        component: HomeComponent        
    },
    {
        path: 'cadastro-usuario',
        component: CadastroUsuarioComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'cadastro-internacao',
        component: CadastroInternacaoComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'consulta-medica',
        component: ConsultaMedicaComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'exame-medico',
        component: ExameMedicoComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'central-leitos',
        component: CentralLeitosComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'login',
        component: LoginComponent,
        canActivate: [AuthGuard]
    },
    // {
    //   path: '',
    //   redirectTo: 'dashboard',
    //   pathMatch: 'full',
    // }
    // {
    //   path: '',
    //   component: AdminLayoutComponent,
    //   children: [{
    //     path: '',
    //     loadChildren: './layouts/admin-layout/admin-layout.module#AdminLayoutModule'
    //   }]
    // }
];

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        RouterModule.forRoot(routes, {
            useHash: true
        })
    ],
    exports: [
    ],
})
export class AppRoutingModule { }
