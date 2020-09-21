import { LoaderService } from './services/loader.service';
import { ApiService } from './services/api.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';
import {
  AgmCoreModule
} from '@agm/core';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { ExameMedicoComponent } from './exame-medico/exame-medico.component';
import { ConsultaMedicaComponent } from './consulta-medica/consulta-medica.component';
import { CentralLeitosComponent } from './central-leitos/central-leitos.component';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    AgmCoreModule.forRoot({
      apiKey: 'YOUR_GOOGLE_MAPS_API_KEY'
    })
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    ExameMedicoComponent,
    ConsultaMedicaComponent,
    CentralLeitosComponent,
  ],
  providers: [ApiService, LoaderService],
  bootstrap: [AppComponent]
})
export class AppModule { }
