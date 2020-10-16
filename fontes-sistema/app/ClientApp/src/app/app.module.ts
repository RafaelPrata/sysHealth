import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CadastroUsuarioComponent } from './cadastro-usuario/cadastro-usuario.component';
import { CadastroInternacaoComponent } from './cadastro-internacao/cadastro-internacao.component';
import { TypographyComponent } from './typography/typography.component';
import { IconsComponent } from './icons/icons.component';
import { MapsComponent } from './maps/maps.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { UpgradeComponent } from './upgrade/upgrade.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from '@angular/material/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner'
import { ExameMedicoComponent } from './exame-medico/exame-medico.component';
import { ConsultaMedicaComponent } from './consulta-medica/consulta-medica.component';
import { CentralLeitosComponent } from 'app/central-leitos/central-leitos.component';
import { ComponentsModule } from './components/components.module';
import { AppRoutingModule } from './app.routing';
import { UsuarioApiService } from './services/usuarioApi.service';
import { LoaderService } from './services/loader.service';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { InternacaoApiService } from './services/internacaoApi.service';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/auth.guard';
import { AutenticacaoService } from './services/autenticacao.service';
import { AgendaApiService } from './services/agendaApi.service';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { DialogComponent } from './components/dialog/dialog.component';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
    imports: [
        BrowserAnimationsModule,
        HttpClientModule,
        ComponentsModule,
        CommonModule,
        // RouterModule.forChild(AppRoutingModule),
        RouterModule,
        AppRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        MatButtonModule,
        MatRippleModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatTooltipModule,
        MatProgressSpinnerModule,
        MatTableModule,
        MatDialogModule
    ],
    declarations: [
        AppComponent,
        DashboardComponent,
        ExameMedicoComponent,
        ConsultaMedicaComponent,
        CadastroUsuarioComponent,
        CadastroInternacaoComponent,
        TypographyComponent,
        IconsComponent,
        MapsComponent,
        NotificationsComponent,
        UpgradeComponent,
        CentralLeitosComponent,
        LoginComponent,
        DialogComponent
    ],
    providers: [
        UsuarioApiService,
        InternacaoApiService,
        AgendaApiService,
        LoaderService,
        AuthGuard,
        AutenticacaoService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
