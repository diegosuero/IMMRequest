
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { WelcomeComponent } from "./welcome/welcome.component";
import { NotFoundComponent } from "./not-found/not-found.component";
import { LoginComponent } from "./login/login.component";
import { MenuAdminsComponent } from './menu-admins/menu-admins.component';
import { ReportesComponent } from './reportes/reportes.component';
import { AdministradoresComponent } from './administradores/administradores.component';
import { ImportarDatosComponent } from './importar-datos/importar-datos.component';
import { SolicitudClienteComponent } from './solicitud-cliente/solicitud-cliente.component';
import { AdministrarTiposComponent } from './administrar-tipos/administrar-tipos.component';
import { SolicitudAdministradoresComponent } from './solicitud-administradores/solicitud-administradores.component';

const routes: Routes = [

  { path: "menuAdmins", component: MenuAdminsComponent },
  { path: "reportes", component: ReportesComponent },
  { path: "administradores", component: AdministradoresComponent },
  { path: "administrarTipos", component: AdministrarTiposComponent },
  { path: "importarDatos", component: ImportarDatosComponent },
  { path: "login", component: LoginComponent },
  { path: "solicitudCliente", component: SolicitudClienteComponent },
  { path: "solicitudAdministradores", component: SolicitudAdministradoresComponent },
  { path: "", component: SolicitudClienteComponent },
  { path: "**", component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
