import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

import { RegistroComponent } from './registro/registro.component';

import { LandingComponent } from './landing/landing.component';
import { FooterComponent } from './footer/footer.component';
import { HeaderComponent } from './header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { VerDetallesComponent } from './ver-detalles/ver-detalles.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule,} from '@angular/material/form-field';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';

import { InicioComponent } from './inicio/inicio.component';
import { MenuComponent } from './menu/menu.component';
import { TransferenciaComponent } from './transferencia/transferencia.component';
import { DatosUsuarioComponent } from './datos-usuario/datos-usuario.component';

import { TransferenciaOtraCuentaComponent } from './transferencia-otra-cuenta/transferencia-otra-cuenta.component';
import {MatRadioModule} from '@angular/material/radio';
import { TransferenciaContactoComponent } from './transferencia-contacto/transferencia-contacto.component';
import { TransferenciaCuentaPropiaComponent } from './transferencia-cuenta-propia/transferencia-cuenta-propia.component';
import { MovPesosComponent } from './mov-pesos/mov-pesos.component';
import { RegistroService } from './Services/registro.service';
import { HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    RegistroComponent,
    LandingComponent,
    FooterComponent,
    HeaderComponent,
    LoginComponent,
    DatosUsuarioComponent,
    TransferenciaComponent,
    InicioComponent,
    MenuComponent,
    VerDetallesComponent,
    TransferenciaOtraCuentaComponent,
    TransferenciaContactoComponent,
    TransferenciaCuentaPropiaComponent,
    MovPesosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    MatSelectModule,
    MatRadioModule,
    HttpClientModule
  ],
  providers: [
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    RegistroService
  ],
 
  bootstrap: [AppComponent]
})
export class AppModule { }
