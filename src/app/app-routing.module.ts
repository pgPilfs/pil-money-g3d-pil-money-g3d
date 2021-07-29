import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { LoginComponent } from './login/login.component';
import { RegistroComponent } from './registro/registro.component';
import { VerDetallesComponent } from './ver-detalles/ver-detalles.component';

const routes: Routes = [
  {path: '', component:LandingComponent},
  {path: 'registro', component:RegistroComponent},
  {path: 'login', component:LoginComponent},
  {path: 'detalles', component:VerDetallesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
