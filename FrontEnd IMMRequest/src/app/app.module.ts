
import { MaterialComponentsModule } from './material.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MatButtonModule, MatCheckboxModule, MatSelectModule} from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { FormsModule } from '@angular/forms';


import { WelcomeComponent } from './welcome/welcome.component';
import { NotFoundComponent } from './not-found/not-found.component';

import { HttpClientModule, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { EjemploInterceptorService } from './ejemplo-interceptor.service';
import { LoginComponent } from './login/login.component';
import { MenuAdminsComponent } from './menu-admins/menu-admins.component';
import { SolicitudClienteComponent } from './solicitud-cliente/solicitud-cliente.component';
import { ReportesComponent } from './reportes/reportes.component';
import { AdministradoresComponent } from './administradores/administradores.component';
import { ImportarDatosComponent } from './importar-datos/importar-datos.component';
import { AdministrarTiposComponent } from './administrar-tipos/administrar-tipos.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { EntreFechasPipe } from './reportes/entre-fechas.pipe';
import { ConEmailPipe } from './reportes/con-email.pipe';
import { SolicitudAdministradoresComponent } from './solicitud-administradores/solicitud-administradores.component';
import { TipoActivosPipe } from './solicitud-cliente/tipo-activos.pipe';
import { SolicitudDatePipe } from './solicitud-cliente/solicitud-date.pipe';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    NotFoundComponent,
    LoginComponent,
    MenuAdminsComponent,
    SolicitudClienteComponent,
    ReportesComponent,
    AdministradoresComponent,
    ImportarDatosComponent,
    AdministrarTiposComponent,
    EntreFechasPipe,
    ConEmailPipe,
    SolicitudAdministradoresComponent,
    TipoActivosPipe,
    SolicitudDatePipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialComponentsModule,
    FormsModule,
    MatSelectModule,
    MatExpansionModule,
    HttpClientModule,
    
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
