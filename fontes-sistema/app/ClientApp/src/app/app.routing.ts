import { NgModule } from '@angular/core';
import { CommonModule, } from '@angular/common';
import { BrowserModule  } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { CadastroInternacaoComponent } from './cadastro-internacao/cadastro-internacao.component';
import { ConsultaMedicaComponent } from './consulta-medica/consulta-medica.component';
import { ExameMedicoComponent } from './exame-medico/exame-medico.component';
import { CentralLeitosComponent } from './central-leitos/central-leitos.component';

const routes: Routes =[
  {
    path: 'dashboard',    
    component: DashboardComponent
  }, 
  {
    path: 'cadastro-usuario',    
    component: CadastroUsuarioComponent
  }, 
  {
    path: 'cadastro-internacao',    
    component: CadastroInternacaoComponent
  }, 
  {
    path: 'consulta-medica',    
    component: ConsultaMedicaComponent
  }, 
  {
    path: 'exame-medico',    
    component: ExameMedicoComponent
  }, 
  {
    path: 'central-leitos',    
    component: CentralLeitosComponent
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
    RouterModule.forRoot(routes,{
       useHash: true
    })
  ],
  exports: [
  ],
})
export class AppRoutingModule { }
