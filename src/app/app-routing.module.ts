import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './inicio/inicio.component';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { RegistroComponent } from './registro/registro.component';
import { TransferenciaComponent } from './transferencia/transferencia.component';
import { VerDetallesComponent } from './ver-detalles/ver-detalles.component';

const routes: Routes = [
  {path: '', component:LandingComponent},
  {path: 'registro', component:RegistroComponent},
  {path: 'login', component:LoginComponent},
  {path: 'inicio', component:InicioComponent},
  {path: 'menu', component:MenuComponent},
  {path: 'transferencia', component:TransferenciaComponent},
  {path: 'detalles', component:VerDetallesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
