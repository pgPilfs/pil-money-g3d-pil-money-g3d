import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { RegistroComponent } from './registro/registro.component';
import { TransferenciaComponent } from './transferencia/transferencia.component';
import { VerDetallesComponent } from './ver-detalles/ver-detalles.component';
import { PaginaPrincipalComponent } from './pagina-principal/pagina-principal.component';
import { TransferenciaOtraCuentaComponent } from './transferencia-otra-cuenta/transferencia-otra-cuenta.component';
import { TransferenciaContactoComponent } from './transferencia-contacto/transferencia-contacto.component';
import { TransferenciaCuentaPropiaComponent } from './transferencia-cuenta-propia/transferencia-cuenta-propia.component';

const routes: Routes = [
  {path: '', component:LandingComponent},
  {path: 'registro', component:RegistroComponent},
  {path: 'login', component:LoginComponent},
 
  {path: 'menu', component:MenuComponent},
  
  {path:'paginaprincipal',component:PaginaPrincipalComponent,children:[
    {path: 'transferencia', component:TransferenciaComponent},
    {path: 'detalles', component:VerDetallesComponent},
    {path: 'inicio', component:InicioComponent},
    {path: 'transferenciaotra',component:TransferenciaOtraCuentaComponent},
    {path:'transferenciacontacto',component:TransferenciaContactoComponent},
    {path:'transferenciacuentapropia',component:TransferenciaCuentaPropiaComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
